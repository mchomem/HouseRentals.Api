namespace HouseRentals.Core.Application.Interfaces;

public interface IHouseService
{
    public Task<HouseDto> CreateAsync(HouseInsertDto entity);
    public Task<HouseDto> DeleteAsync(long id);
    public Task<HouseDto> GetAsync(long id);
    public Task<IEnumerable<HouseDto>> GetAllAsync(HouseFilter filter, string includes = "");
    public Task<HouseDto> UpdateAsync(long id, HouseDto entity);
}
