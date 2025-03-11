namespace HouseRentals.Core.Application.Services;

public class HouseService : IHouseService
{
    private readonly IHouseRepository _houseRepository;
    private readonly IMapper _mapper;

    public HouseService(IHouseRepository houseRepository, IMapper mapper)
    {
        _houseRepository = houseRepository;
        _mapper = mapper;
    }

    public async Task<HouseDto> CreateAsync(HouseInsertDto entity)
    {
        var house = new House(entity.Address, entity.DailyPrice, entity.NumberOfRooms, entity.Description, entity.ImageFileName);
        return _mapper.Map<HouseDto>(await _houseRepository.CreateAsync(house));
    }

    public async Task<HouseDto> DeleteAsync(long id)
    {
        var house = await _houseRepository.GetAsync(id);

        if(house is null)
            throw new HouseNotFoundException();

        house.Delete();

        return _mapper.Map<HouseDto>(await _houseRepository.UpdateAsync(house));
    }

    public async Task<IEnumerable<HouseDto>> GetAllAsync(HouseFilter filter)
    {
        Expression<Func<House, bool>> expressionFilter =
            x => (
                (string.IsNullOrEmpty(filter.Address) || x.Address.Contains(filter.Address))
                && (!filter.DailyPriceStart.HasValue || x.DailyPrice >= filter.DailyPriceStart.Value)
                && (!filter.DailyPriceEnd.HasValue || x.DailyPrice <= filter.DailyPriceEnd.Value)
                && (filter.Status == null || x.Status == filter.Status)
                && (!filter.NumberOfRoomsStart.HasValue || x.NumberOfRooms >= filter.NumberOfRoomsStart.Value)
                && (!filter.NumberOfRoomsEnd.HasValue || x.NumberOfRooms <= filter.NumberOfRoomsEnd.Value)
                && !x.Deleted
            );

        IEnumerable <House> houses = await _houseRepository.GetAllAsync(expressionFilter);
        return _mapper.Map<IEnumerable<HouseDto>>(houses);
    }

    public async Task<HouseDto> GetAsync(long id)
    {
        var house = await _houseRepository.GetAsync(id);
        return _mapper.Map<HouseDto>(house);
    }

    public async Task<HouseDto> UpdateAsync(long id, HouseDto entity)
    {
        var house = await _houseRepository.GetAsync(id);

        if (house is null)
            throw new HouseNotFoundException();

        house.Update(entity.Address, entity.DailyPrice, entity.Status, entity.NumberOfRooms, entity.Description, entity.ImageFileName);

        return _mapper.Map<HouseDto>(await _houseRepository.UpdateAsync(house));
    }
}
