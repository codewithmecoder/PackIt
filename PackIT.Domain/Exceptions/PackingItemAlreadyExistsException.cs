using PackIT.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class PackingItemAlreadyExistsException : PackItException
{
    public PackingItemAlreadyExistsException(string listName, string itemName)
        : base($"Packing list: '{listName}' already defined item '{itemName}'")
    {
        ListName = listName;
        ItemName = itemName;
    }

    public string ListName { get; }
    public string ItemName { get; }
}
