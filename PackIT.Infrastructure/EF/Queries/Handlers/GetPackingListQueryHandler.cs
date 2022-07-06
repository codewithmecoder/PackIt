using Microsoft.EntityFrameworkCore;
using PackIT.Abstraction.Queries;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Queries.Handlers;

internal sealed class GetPackingListQueryHandler : IQueryHandler<GetPackingListQuery, PackingListDto>
{
    private readonly DbSet<PackingListReadModel> _packingList;
    public GetPackingListQueryHandler(ReadDbContext context)
    {
        _packingList = context.PackingLists;
    }

    public Task<PackingListDto> HandleAsync(GetPackingListQuery query)
    {
        return _packingList
            .Include(i => i.Items)
            .Where(i => i.Id == query.Id)
            .Select(i => i.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync()!;
    }
}
