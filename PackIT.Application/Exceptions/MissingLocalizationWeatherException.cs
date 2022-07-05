using PackIT.Abstraction.Exceptions;
using PackIT.Domain.ValueObjects;

namespace PackIT.Application.Exceptions;

public class MissingLocalizationWeatherException : PackItException
{
    public MissingLocalizationWeatherException(Localization localization)
        : base($"Couldn't fetch weather for localization '{localization.Country}/{localization.City}'")
    {
    }
}
