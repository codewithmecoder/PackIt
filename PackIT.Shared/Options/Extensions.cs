using Microsoft.Extensions.Configuration;

namespace PackIT.Shared.Options;

public static class Extensions
{
    public static TOptions GetOptions<TOptions>(this IConfiguration config, string sectionName)
        where TOptions : new()
    {
        var options = new TOptions();

        config.GetSection(sectionName).Bind(options);

        return options;
    }
}
