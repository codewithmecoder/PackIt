namespace PackIT.Infrastructure.EF.Models;

internal class LocalizationReadModel
{
    public string? City { get; set; }
    public string? Country { get; set; }
    public static LocalizationReadModel Create(string value)
    {
        var splitLocalization = value.Split(",");
        return new LocalizationReadModel
        {
            City = splitLocalization[0],
            Country = splitLocalization[^1],
        };
    }
    public override string? ToString()
    {
        return $"{City},{Country}";
    }
}
