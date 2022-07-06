using PackIT.Application.DTO;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Queries;

internal static class Extensions
{
    public static PackingListDto AsDto(this PackingListReadModel x)
    => new()
    {
        Id = x.Id,
        Name = x.Name,
        Localization = new LocalizationDto
        {
            City = x.Localization?.City,
            Country = x.Localization?.Country,
        },
        Items = x.Items?.Select(i => new PackingItemDto
        {
            IsPacked = i.IsPacked,
            Name = i.Name,
            Qty = i.Qty,
        })
    };
}