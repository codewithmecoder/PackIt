using PackIT.Abstraction.Commands;
using PackIT.Domain.Consts;

namespace PackIT.Application.Commands;

public record CreatePackingListWithItemCommand(
    Guid Id,
    string Name,
    ushort Days,
    Gender Gender,
    LocalizationWriteModel Localization) : ICommand;
public record LocalizationWriteModel(string City, string Country);


