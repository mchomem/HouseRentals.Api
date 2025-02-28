namespace HouseRentals.Core.Application.Interfaces;

public interface ITenantService
{
    public Task<TenantDto> CreateAsync(TenantInsertDto entity);
    public Task<TenantDto> DeleteAsync(long id);
    public Task<TenantDto> GetAsync(long id);
    public Task<IEnumerable<TenantDto>> GetAllAsync(TenantFilter filter, string includes = "");
    public Task<TenantDto> UpdateAsync(long id, TenantDto entity);
}
