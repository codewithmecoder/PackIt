using PackIT.Abstraction.Queries;
using PackIT.Application.DTO;
using PackIT.Domain.Repositories;

namespace PackIT.Application.Queries.Handlers;

public class GetPackingListQueryHandler : IQueryHandler<GetPackingListQuery, PackingListDto>
{
    private readonly IPackingListRepository _repository;

    public GetPackingListQueryHandler(IPackingListRepository repository)
    {
        _repository = repository;
    }

    public async Task<PackingListDto> HandleAsync(GetPackingListQuery query)
    {
        var packingList = await _repository.GetAsync(query.Id);
        throw new NotImplementedException();
    }
}
