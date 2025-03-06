namespace HouseRentals.Core.Application.Interfaces;

public interface IRentalService
{
    public Task<RentalDto> CreateAsync(RentalInsertDto entity);
    public Task<RentalDto> GetAsync(long id);
    public Task<IEnumerable<RentalDto>> GetAllAsync(RentalFilter filter);
    public Task<RentalDto> UpdateAsync(long id, RentalUpdateDto entity);
    public Task<RentalDto> RentAsync(long rentalId, long tenantId, decimal discont);
    public Task<RentalDto> UnRentAsync(long id);
}
