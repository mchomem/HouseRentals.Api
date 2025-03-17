namespace HouseRentals.Infrastructure.Persistence.Repositories;

public class TenantRepository : ITenantRepository
{
    private readonly IRepositoryBase<Tenant> _repositoryBase;

    public TenantRepository(IRepositoryBase<Tenant> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<Tenant> CreateAsync(Tenant entity)
    {
       var tenant = await _repositoryBase.CreateAsync(entity);
        return tenant;
    }

    public async Task<Tenant> DeleteAsync(Tenant entity)
    {
        var tenant = await _repositoryBase.DeleteAsync(entity);
        return tenant;
    }

    public async Task<Tenant> GetAsync(long id)
    {
        var tenant = await _repositoryBase.GetAsync(id);
        return tenant;
    }

    public async Task<IEnumerable<Tenant>> GetAllAsync(Expression<Func<Tenant, bool>> filter, IEnumerable<Expression<Func<Tenant, object>>>? includes = null)
    {
        var tenants = await _repositoryBase.GetAllAsync(filter, includes);
        return tenants;
    }

    public async Task<Tenant> UpdateAsync(Tenant entity)
    {
        var tenant = await _repositoryBase.UpdateAsync(entity);
        return tenant;
    }
}
