namespace HouseRentals.Domain.Exceptions.Rental;

public class RentalInvalidDiscountException : RentalException
{
    public RentalInvalidDiscountException(string message = DefaultMessages.RentalInvalidDiscount) : base(message)
    {
    }
}
