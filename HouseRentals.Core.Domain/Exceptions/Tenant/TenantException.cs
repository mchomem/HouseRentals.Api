namespace HouseRentals.Core.Domain.Exceptions.Tenant;

public class TenantException : Exception
{
    public TenantException(string message) : base(message) { }
}
