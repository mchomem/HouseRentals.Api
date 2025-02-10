namespace HouseRentals.Database.Repositories;

public class HouseRepository : IHouseRepository
{
    private readonly IRepositoryBase<House> _repositoryBase;

    public HouseRepository(IRepositoryBase<House> repositoryBase)
        => _repositoryBase = repositoryBase;

    public async Task<House> CreateAsync(House entity)
       => await _repositoryBase.CreateAsync(entity);

    public async Task<House> DeleteAsync(House entity)
        => await _repositoryBase.DeleteAsync(entity);

    public async Task<House> GetAsync(long id)
        => await _repositoryBase.GetAsync(id);

    public async Task<IEnumerable<House>> GetAllAsync(Expression<Func<House, bool>> filter, string includes = "")
        => await _repositoryBase.GetAllAsync(filter, includes);

    public async Task<House> UpdateAsync(House entity)
        => await _repositoryBase.UpdateAsync(entity);
}
