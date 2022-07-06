using Microsoft.EntityFrameworkCore;
using PackIT.Abstraction.Queries;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Queries.Handlers;

internal sealed class SearchPackingListsHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
{
    private readonly DbSet<PackingListReadModel> _packingList;

    public SearchPackingListsHandler(ReadDbContext context)
    {
        _packingList = context.PackingLists;
    }

    public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
    {
        var dbQuery = _packingList
            .Include(i => i.Items)
            .AsQueryable();

        if (!string.IsNullOrEmpty(query.SearchPhrase))
        {
            dbQuery = dbQuery.Where(i =>
                Microsoft.EntityFrameworkCore.EF.Functions.ILike(i.Name!, $"%{query.SearchPhrase}%"));
        }

        return await dbQuery
            .Select(i => i.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}
