namespace HouseRentals.Core.Domain.Exceptions;

public class RentalException : Exception
{
    public RentalException(string message) : base(message) { }
}
