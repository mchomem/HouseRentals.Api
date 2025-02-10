namespace HouseRentals.Application.Interfaces;

public interface IRentalService
{
    public Task<RentalDto> CreateAsync(RentalInsertDto entity);
    public Task<RentalDto> GetAsync(long id);
    public Task<IEnumerable<RentalDto>> GetAllAsync(RentalFilter filter);
    public Task<RentalDto> UpdateAsync(long id, RentalUpdateDto entity);
    public Task<RentalDto> UnRent(long id);
}
