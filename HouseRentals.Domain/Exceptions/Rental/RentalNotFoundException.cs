namespace HouseRentals.Domain.Exceptions.Rental;

public class RentalNotFoundException : RentalException
{
    public RentalNotFoundException(string message = DefaultMessages.RentalNotFound) : base(message)
    {
    }
}
