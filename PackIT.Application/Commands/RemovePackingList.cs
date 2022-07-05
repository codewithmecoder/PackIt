using PackIT.Abstraction.Commands;

namespace PackIT.Application.Commands;

public record RemovePackingList(Guid Id) : ICommand;