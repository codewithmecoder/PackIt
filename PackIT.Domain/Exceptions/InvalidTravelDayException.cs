using PackIT.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class InvalidTravelDayException : PackItException
{
    public InvalidTravelDayException(ushort days) : base($"Value '{days}' is invalid travel day.")
    {
        Days = days;
    }

    public ushort Days { get; }
}
