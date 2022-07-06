using PackIT.Abstraction.Commands;
using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;

namespace PackIT.Application.Commands.Handlers;

public class CreatePackingListWithItemCommandHandler : ICommandHandler<CreatePackingListWithItemCommand>
{
    private readonly IPackingListReadService _readService;
    private readonly IWeatherService _weatherService;
    private readonly IPackingListRepository _repository;
    private readonly IPackingListFactory _factory;

    public CreatePackingListWithItemCommandHandler(
        IPackingListReadService packingListService,
        IPackingListRepository packingListRepository,
        IPackingListFactory packingListFactory,
        IWeatherService weatherService)
    {
        _readService = packingListService;
        _repository = packingListRepository;
        _factory = packingListFactory;
        _weatherService = weatherService;
    }

    public async Task HandleAsync(CreatePackingListWithItemCommand command)
    {
        var (id, name, days, gender, localizationWriteModel) = command;
        if (await _readService.ExistsByNameAsync(name))
        {
            throw new PackingListAlreadyExistsException(name);
        }

        var localization = new Localization(
            localizationWriteModel.City,
            localizationWriteModel.Country);
        var weather = await _weatherService.GetWeatherAsync(localization);

        if (weather is null)
        {
            throw new MissingLocalizationWeatherException(localization);
        }

        var packingList = _factory.CreateWithDefaultItems(
            id,
            name,
            days,
            gender,
            weather.Temperature,
            localization);

        await _repository.AddAsync(packingList);
    }
}
