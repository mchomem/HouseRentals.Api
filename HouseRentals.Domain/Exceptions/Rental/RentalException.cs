namespace HouseRentals.Domain.Exceptions.Rental;

public class RentalException : Exception
{
    public RentalException(string message) : base(message)
    {
    }
}
