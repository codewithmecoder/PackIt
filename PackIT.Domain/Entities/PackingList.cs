using PackIT.Abstraction.Domain;
using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Entities;

public class PackingList : AggregateRoot<Guid>
{
    public PackingListId Id { get; private set; }

    private PackingListName _name;
    private Localization _localization;
    private readonly LinkedList<PackingItem> _items = new();

    internal PackingList(
        PackingListId id,
        PackingListName name,
        Localization localization)
    {
        Id = id;
        _name = name;
        _localization = localization;
    }
    public void AddItem(PackingItem item)
    {
        var alreadExists = _items.Any(i => i.Name == item.Name);
        if (alreadExists)
            throw new PackingItemAlreadyExistsException(_name, item?.Name!);

        _items.AddLast(item);
        AddEvent(new PackingItemAdded(this, item));
    }

    public void AddItems(IEnumerable<PackingItem> items)
    {
        foreach (var i in items)
        {
            AddItem(i);
        }
    }

    public void PackItem(string itemName)
    {
        var item = GetItem(itemName);
        var packedItem = item with { IsPacked = true };

        _items.Find(item)!.Value = packedItem;
        AddEvent(new PackingItemPacked(this, item));
    }

    public void RemoveItem(string itemName)
    {
        var item = GetItem(itemName);
        _items.Remove(item);
        AddEvent(new PackingItemRemoved(this, item));
    }

    private PackingItem GetItem(string itemName)
    {
        var item = _items.FirstOrDefault(i => i.Name == itemName);
        if (item == null)
        {
            throw new PackingItemNotFoundException(itemName);
        }
        return item;
    }
}
