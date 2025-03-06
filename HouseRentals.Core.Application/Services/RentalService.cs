namespace HouseRentals.Core.Application.Services;

public class RentalService : IRentalService
{
    private readonly IRentalRepository _rentalRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IHouseRepository _houseRepository;
    private readonly IMapper _mapper;

    public RentalService(
        IRentalRepository rentalRepository
        , ITenantRepository tenantRepository
        , IHouseRepository houseRepository
        , IMapper mapper)
    {
        _rentalRepository = rentalRepository;
        _houseRepository = houseRepository;
        _tenantRepository = tenantRepository;
        _mapper = mapper;
    }

    public async Task<RentalDto> CreateAsync(RentalInsertDto entity)
    {
        var house = await _houseRepository.GetAsync(entity.HouseId);

        if (house is null)
            throw new HouseNotFoundException();

        var tenant = await _tenantRepository.GetAsync(entity.TenantId);

        if (tenant is null)
            throw new TenantNotFoundException();

        var rental = new Rental(entity.HouseId, house, entity.TenantId, tenant, entity.StartDate, entity.EndDate, entity.Observation);

        return _mapper.Map<RentalDto>(await _rentalRepository.CreateAsync(rental));
    }

    public async Task<IEnumerable<RentalDto>> GetAllAsync(RentalFilter filter)
    {
        Expression<Func<Rental, bool>> expressionFilter =
            x => (
                (!filter.HouseId.HasValue || x.HouseId == filter.HouseId)
                && (!filter.TenantId.HasValue || x.TenantId == filter.TenantId)

                && (!filter.StartDateStart.HasValue) || x.StartDate >= filter.StartDateStart
                && (!filter.StartDateEnd.HasValue) || x.StartDate <= filter.StartDateEnd
                && (!filter.EndDateStart.HasValue) || x.EndDate >= filter.EndDateStart
                && (!filter.EndDateEnd.HasValue) || x.EndDate <= filter.EndDateEnd

                && (!filter.DiscountStart.HasValue) || x.Discount >= filter.DiscountStart
                && (!filter.DiscountEnd.HasValue) || x.Discount <= filter.DiscountEnd

                && (!filter.TotalPriceStart.HasValue) || x.TotalPrice >= filter.TotalPriceStart
                && (!filter.TotalPriceEnd.HasValue) || x.TotalPrice <= filter.TotalPriceEnd

                && (!filter.TotalToPayStart.HasValue) || x.TotalToPay >= filter.TotalToPayStart
                && (!filter.TotalToPayEnd.HasValue) || x.TotalToPay <= filter.TotalToPayEnd

                && (string.IsNullOrEmpty(filter.Observation) || x.Observation.Contains(filter.Observation))

                && (!filter.RentPaid.HasValue) || x.RentPaid == filter.RentPaid

                && (!filter.RentPaymentDateStart.HasValue) || x.RentPaymentDate >= filter.RentPaymentDateStart
                && (!filter.RentPaymentDateEnd.HasValue) || x.RentPaymentDate <= filter.RentPaymentDateEnd
            );

        var rentals = await _rentalRepository.GetAllAsync(expressionFilter, $"{nameof(Tenant)},{nameof(House)}");
        return _mapper.Map<IEnumerable<RentalDto>>(rentals);
    }

    public async Task<RentalDto> GetAsync(long id)
    {
        var remtal = await _rentalRepository.GetAsync(x => x.Id == id, $"{nameof(Tenant)},{nameof(House)}");
        return _mapper.Map<RentalDto>(remtal);
    }

    public async Task<RentalDto> UpdateAsync(long id, RentalUpdateDto entity)
    {
        var rental = await _rentalRepository.GetAsync(id);

        if (rental is null)
            throw new RentalNotFoundException();

        var house = await _houseRepository.GetAsync(entity.HouseId);

        if (house is null)
            throw new HouseNotFoundException();

        var tenant = await _tenantRepository.GetAsync(entity.TenantId);

        if (tenant is null)
            throw new TenantNotFoundException();

        rental.Update(entity.HouseId, house, entity.TenantId, tenant, entity.StartDate, entity.EndDate, entity.Discount,  entity.Observation);

        return _mapper.Map<RentalDto>(await _rentalRepository.UpdateAsync(rental));
    }

    public async Task<RentalDto> RentAsync(long rentalId, long tenantId, decimal discont)
    {
        var rental = await _rentalRepository.GetAsync(rentalId);

        if (rental is null)
            throw new RentalNotFoundException();

        var house = await _houseRepository.GetAsync(rental.HouseId);

        if (house is null)
            throw new HouseNotFoundException();

        var rentalTenant = await _tenantRepository.GetAsync(rental.TenantId);

        if (rentalTenant is null)
            throw new TenantNotFoundException();

        var informedTenant = await _tenantRepository.GetAsync(tenantId);

        if (informedTenant is null)
            throw new TenantNotFoundException();

        rental.Rent(discont, rentalTenant, informedTenant);

        return _mapper.Map<RentalDto>(await _rentalRepository.UpdateAsync(rental));
    }

    public async Task<RentalDto> UnRentAsync(long id)
    {
        var rental = await _rentalRepository.GetAsync(id);

        if (rental is null)
            throw new RentalNotFoundException();

        var house = await _houseRepository.GetAsync(rental.HouseId);

        if (house is null)
            throw new HouseNotFoundException();

        var tenant = await _tenantRepository.GetAsync(rental.TenantId);

        if (tenant is null)
            throw new TenantNotFoundException();

        rental.UnRent();

        return _mapper.Map<RentalDto>(await _rentalRepository.UpdateAsync(rental));
    }
}
