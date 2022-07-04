using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

public record PackingItem
{
    public string? Name { get; }
    public uint Qty { get; }
    public bool IsPacked { get; init; }

    public PackingItem(
        string? name,
        uint qty,
        bool isPacked = false)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new EmptyPackingListItemNameException();
        Name = name;
        Qty = qty;
        IsPacked = isPacked;
    }
}
