namespace HouseRentals.Core.Domain.Exceptions.Rental;

public class RentalDaysEqualToZeroException : RentalException
{
    public RentalDaysEqualToZeroException(string message = DefaultMessages.RentalDaysEqualsToZero) : base(message)
    {
    }
}
