using Microsoft.EntityFrameworkCore;
using PackIT.Domain.Entities;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.EF.Contexts;

namespace PackIT.Infrastructure.EF.Repositories;

internal sealed class PostgresPackingListRepository : IPackingListRepository
{
    private readonly DbSet<PackingList> _packingLists;
    private readonly WriteDbContext _writeDbContext;

    public PostgresPackingListRepository(WriteDbContext writeDbContext)
    {
        _writeDbContext = writeDbContext;
        _packingLists = writeDbContext.PackingLists;
    }

    public async Task AddAsync(PackingList item)
    {
        await _packingLists.AddAsync(item);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(PackingList item)
    {
        _packingLists.Remove(item);
        await _writeDbContext.SaveChangesAsync();
    }

    public Task<PackingList> GetAsync(PackingListId id)
    => _packingLists.Include("_items").SingleOrDefaultAsync(i => i.Id == id)!;

    public async Task UpdateAsync(PackingList item)
    {
        _packingLists.Update(item);
        await _writeDbContext.SaveChangesAsync();
    }
}
