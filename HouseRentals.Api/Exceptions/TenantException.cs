namespace HouseRentals.Api.Exceptions;

public class TenantException : Exception
{
    public TenantException(string message) : base(message)
    {
    }
}
