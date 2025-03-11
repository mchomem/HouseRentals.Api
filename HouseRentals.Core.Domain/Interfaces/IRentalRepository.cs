namespace HouseRentals.Core.Domain.Interfaces;

public interface IRentalRepository
{
    public Task<Rental> CreateAsync(Rental entity);
    public Task<Rental> GetAsync(long id);
    public Task<Rental> GetAsync(Expression<Func<Rental, bool>> filter, IEnumerable<string>? includes = null);
    public Task<IEnumerable<Rental>> GetAllAsync(Expression<Func<Rental, bool>> filter, IEnumerable<string>? includes = null);
    public Task<Rental> UpdateAsync(Rental entity);
}
