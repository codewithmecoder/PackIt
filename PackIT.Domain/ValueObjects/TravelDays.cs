using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

public class TravelDays
{
    public ushort Value { get; set; }

    public TravelDays(ushort value)
    {
        if (value is 0 or > 100)
        {
            throw new InvalidTravelDayException(value);
        }
        Value = value;
    }

    public static implicit operator ushort(TravelDays id)
        => id.Value!;

    public static implicit operator TravelDays(ushort id)
        => new(id);
}
