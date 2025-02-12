namespace HouseRentals.Database.Repositories;

public class HouseRepository : IHouseRepository
{
    private readonly IRepositoryBase<House> _repositoryBase;

    public HouseRepository(IRepositoryBase<House> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<House> CreateAsync(House entity)
    {
        var house = await _repositoryBase.CreateAsync(entity);
        return house;
    }

    public async Task<House> DeleteAsync(House entity)
    {
        var house = await _repositoryBase.DeleteAsync(entity);
        return house;
    }

    public async Task<House> GetAsync(long id)
    {
        var house = await _repositoryBase.GetAsync(id);
        return house;
    }

    public async Task<IEnumerable<House>> GetAllAsync(Expression<Func<House, bool>> filter, string includes = "")
    {
        var houses = await _repositoryBase.GetAllAsync(filter, includes);
        return houses;
    }

    public async Task<House> UpdateAsync(House entity)
    {
        var house = await _repositoryBase.UpdateAsync(entity);
        return house;
    }
}
