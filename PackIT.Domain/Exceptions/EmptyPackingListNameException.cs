using PackIT.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

internal class EmptyPackingListNameException : PackItException
{
    public EmptyPackingListNameException() : base("Packing list name cannot be empty.")
    {
    }
}
