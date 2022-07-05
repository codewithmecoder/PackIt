using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Repositories;

public interface IPackingListRepository
{
    Task<PackingList> GetAsync(PackingListId id);
    Task AddAsync(PackingList item);
    Task UpdateAsync(PackingList item);
    Task DeleteAsync(PackingList item);
}
