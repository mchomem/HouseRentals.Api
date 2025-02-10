namespace HouseRentals.Application.Services;

public class TenantService : ITenantService
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IMapper _mapper;

    public TenantService(ITenantRepository tenantRepository, IMapper mapper)
    {
        _tenantRepository = tenantRepository;
        _mapper = mapper;
    }

    public async Task<TenantDto> CreateAsync(TenantDto entity)
    {
        Tenant tenant = new(entity.FullName, entity.Email, entity.PhoneNumber, entity.BirthDate);        
        return _mapper.Map<TenantDto>(await _tenantRepository.CreateAsync(tenant));
    }

    public async Task<TenantDto> DeleteAsync(long id)
    {
        Tenant tenant = await _tenantRepository.GetAsync(id);

        if (tenant is null)
            throw new TenantException(DefaultMessages.TenantNotFound);

        tenant.Delete();

        return _mapper.Map<TenantDto>(await _tenantRepository.UpdateAsync(tenant));
    }

    public async Task<IEnumerable<TenantDto>> GetAllAsync(TenantFilter filter, string includes = "")
    {
        Expression<Func<Tenant, bool>> expressionFilter =
            x => (
                (string.IsNullOrEmpty(filter.FullName) || x.FullName.Contains(filter.FullName))
                && (string.IsNullOrEmpty(filter.Email) || x.FullName.Contains(filter.Email))
                && (string.IsNullOrEmpty(filter.PhoneNumber) || x.FullName.Contains(filter.PhoneNumber))
                && (!filter.BirthDateStart.HasValue || x.BirthDate >= filter.BirthDateStart)
                && (!filter.BirthDateEnd.HasValue || x.BirthDate <= filter.BirthDateEnd)
                && !x.Deleted
            );

        IEnumerable<Tenant> tenants = await _tenantRepository.GetAllAsync(expressionFilter);
        return _mapper.Map<IEnumerable<TenantDto>>(tenants);
    }

    public async Task<TenantDto> GetAsync(long id)
    {
        Tenant tenant = await _tenantRepository.GetAsync(id);
        return _mapper.Map<TenantDto>(tenant);
    }

    public async Task<TenantDto> UpdateAsync(long id, TenantDto entity)
    {
        Tenant tenant = await _tenantRepository.GetAsync(id);

        if (tenant is null)
            throw new TenantException(DefaultMessages.TenantNotFound);

        tenant.Update(entity.FullName, entity.Email, entity.PhoneNumber, entity.BirthDate);

        return _mapper.Map<TenantDto>(await _tenantRepository.UpdateAsync(tenant));
    }
}
