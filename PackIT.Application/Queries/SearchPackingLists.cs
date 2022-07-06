using PackIT.Abstraction.Queries;
using PackIT.Application.DTO;

namespace PackIT.Application.Queries;

public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
{
    public string? SearchPhrase { get; set; }
}
