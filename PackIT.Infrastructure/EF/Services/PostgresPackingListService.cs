using Microsoft.EntityFrameworkCore;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Services;

internal sealed class PostgresPackingListService : IPackingListReadService
{
    private readonly DbSet<PackingListReadModel> _packingLists;

    public PostgresPackingListService(ReadDbContext ctx)
    {
        _packingLists = ctx.PackingLists;
    }

    public Task<bool> ExistsByNameAsync(string name)
    => _packingLists.AnyAsync(i => i.Name == name);
}
