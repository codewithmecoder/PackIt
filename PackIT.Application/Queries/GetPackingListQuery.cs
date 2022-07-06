using PackIT.Abstraction.Queries;
using PackIT.Application.DTO;

namespace PackIT.Application.Queries;

public class GetPackingListQuery : IQuery<PackingListDto>
{
    public Guid Id { get; set; }

}
