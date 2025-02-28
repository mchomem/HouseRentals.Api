namespace HouseRentals.Core.Application.Filters;

public class TenantFilter
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDateStart { get; set; }
    public DateTime? BirthDateEnd { get; set; }
}
