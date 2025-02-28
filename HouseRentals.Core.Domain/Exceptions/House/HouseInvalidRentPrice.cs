namespace HouseRentals.Core.Domain.Exceptions.House;

public class HouseInvalidRentPrice : RentalException
{
    public HouseInvalidRentPrice(string message = DefaultMessages.HouseInvalidRentPrice) : base(message)
    {
    }
}
