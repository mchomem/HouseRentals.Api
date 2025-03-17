namespace HouseRentals.Infrastructure.Persistence.Repositories;

public class RentalRepository : IRentalRepository
{
    private readonly IRepositoryBase<Rental> _repositoryBase;

    public RentalRepository(IRepositoryBase<Rental> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<Rental> CreateAsync(Rental entity)
    {
        var rental = await _repositoryBase.CreateAsync(entity);
        return rental;
    }

    public async Task<IEnumerable<Rental>> GetAllAsync(Expression<Func<Rental, bool>> filter, IEnumerable<Expression<Func<Rental, object>>>? includes = null)
    {
        var rental = await _repositoryBase.GetAllAsync(filter, includes);
        return rental;
    }

    public async Task<Rental> GetAsync(long id)
    {
         var rental = await _repositoryBase.GetAsync(id);
        return rental;
    }

    public async Task<Rental> GetAsync(Expression<Func<Rental, bool>> filter, IEnumerable<Expression<Func<Rental, object>>>? includes = null)
    {
        var rental = await _repositoryBase.GetAsync(filter, includes);
        return rental;
    }

    public async Task<Rental> UpdateAsync(Rental entity)
    {
        var rental = await _repositoryBase.UpdateAsync(entity);
        return rental;
    }
}
