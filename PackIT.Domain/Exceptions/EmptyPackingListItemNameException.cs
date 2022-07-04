using PackIT.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingListItemNameException : PackItException
{
    public EmptyPackingListItemNameException()
        : base("Packing item name cannot be empty.")
    {
    }
}
