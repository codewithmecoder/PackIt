using PackIT.Abstraction.Queries;
using PackIT.Application.DTO;

namespace PackIT.Application.Queries.Handlers;

public class SearchPackingListsHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
{
    //private readonly Pack
    public Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
    {
        throw new NotImplementedException();
    }
}
