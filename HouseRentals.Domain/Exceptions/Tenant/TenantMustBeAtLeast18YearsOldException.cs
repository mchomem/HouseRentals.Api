namespace HouseRentals.Domain.Exceptions.Tenant;

public class TenantMustBeAtLeast18YearsOldException : TenantException
{
    public TenantMustBeAtLeast18YearsOldException(string message = DefaultMessages.TenantMustBeAtLeast18YearsOld) : base(message)
    {
    }
}
