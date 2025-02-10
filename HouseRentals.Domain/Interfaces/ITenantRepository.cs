namespace HouseRentals.Domain.Interfaces;

public interface ITenantRepository
{
    public Task<Tenant> CreateAsync(Tenant entity);
    public Task<Tenant> DeleteAsync(Tenant entity);
    public Task<Tenant> GetAsync(long id);
    public Task<IEnumerable<Tenant>> GetAllAsync(Expression<Func<Tenant, bool>> filter, string includes = "");
    public Task<Tenant> UpdateAsync(Tenant entity);
}
