namespace HouseRentals.Core.Domain.Interfaces;

public interface ITenantRepository
{
    public Task<Tenant> CreateAsync(Tenant entity);
    public Task<Tenant> DeleteAsync(Tenant entity);
    public Task<Tenant> GetAsync(long id);
    public Task<IEnumerable<Tenant>> GetAllAsync(Expression<Func<Tenant, bool>> filter, IEnumerable<string>? includes = null);
    public Task<Tenant> UpdateAsync(Tenant entity);
}
