using PackIT.Abstraction.Domain;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Events;

public record PackingItemAdded(PackingList PackingList, PackingItem PackingItem) : IDomainEvent
{
}
