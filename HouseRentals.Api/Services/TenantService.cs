namespace HouseRentals.Api.Services;

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

        return _mapper.Map<TenantDto>(await _tenantRepository.DeleteAsync(tenant));
    }

    public Task<IEnumerable<TenantDto>> GetAllAsync(Expression<Func<TenantDto, bool>> filter, string includes = "")
    {
        throw new NotImplementedException();
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
