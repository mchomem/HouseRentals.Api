namespace HouseRentals.Core.Domain.Interfaces;

public interface IHouseRepository
{
    public Task<House> CreateAsync(House entity);
    public Task<House> DeleteAsync(House entity);
    public Task<House> GetAsync(long id);
    public Task<IEnumerable<House>> GetAllAsync(Expression<Func<House, bool>> filter, IEnumerable<string>? includes = null);
    public Task<House> UpdateAsync(House entity);
}
