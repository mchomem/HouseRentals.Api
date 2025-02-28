namespace HouseRentals.Core.Domain.Exceptions.Tenant;

public class TenantNotFoundException : TenantException
{
    public TenantNotFoundException(string message = DefaultMessages.TenantNotFound) : base(message)
    {
    }
}
