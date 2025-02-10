namespace HouseRentals.Application.Filters;

public class TenantFilter
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime? BirthDateStart { get; set; }
    public DateTime? BirthDateEnd { get; set; }
}
