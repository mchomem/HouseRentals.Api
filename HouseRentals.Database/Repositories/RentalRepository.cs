namespace HouseRentals.Database.Repositories;

public class RentalRepository : IRentalRepository
{
    private readonly IRepositoryBase<Rental> _repositoryBase;

    public RentalRepository(IRepositoryBase<Rental> repositoryBase)
        => _repositoryBase = repositoryBase;

    public async Task<Rental> CreateAsync(Rental entity)
        => await _repositoryBase.CreateAsync(entity);

    public async Task<IEnumerable<Rental>> GetAllAsync(Expression<Func<Rental, bool>> filter, string includes = "")
        => await _repositoryBase.GetAllAsync(filter, includes);

    public async Task<Rental> GetAsync(long id)
        => await _repositoryBase.GetAsync(id);

    public async Task<Rental> GetAsync(Expression<Func<Rental, bool>> filter, string includes = "")
        => await _repositoryBase.GetAsync(filter, includes);

    public async Task<Rental> UpdateAsync(Rental entity)
        => await _repositoryBase.UpdateAsync(entity);
}
