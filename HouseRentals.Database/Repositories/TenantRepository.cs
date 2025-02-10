namespace HouseRentals.Api.Repositories;

public class TenantRepository : ITenantRepository
{
    private readonly IRepositoryBase<Tenant> _repositoryBase;

    public TenantRepository(IRepositoryBase<Tenant> repositoryBase)
        => _repositoryBase = repositoryBase;

    public async Task<Tenant> CreateAsync(Tenant entity)
       => await _repositoryBase.CreateAsync(entity);

    public async Task<Tenant> DeleteAsync(Tenant entity)
        => await _repositoryBase.DeleteAsync(entity);

    public async Task<Tenant> GetAsync(long id)
        => await _repositoryBase.GetAsync(id);

    public async Task<IEnumerable<Tenant>> GetAllAsync(Expression<Func<Tenant, bool>> filter, string includes = "")
        => await _repositoryBase.GetAllAsync(filter, includes);

    public async Task<Tenant> UpdateAsync(Tenant entity)
        => await _repositoryBase.UpdateAsync(entity);
}
