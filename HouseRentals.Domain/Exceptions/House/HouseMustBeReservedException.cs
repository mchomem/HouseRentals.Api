namespace HouseRentals.Domain.Exceptions.House;

public class HouseMustBeReservedException : HouseException
{
    public HouseMustBeReservedException(string message = DefaultMessages.HouseMustBeReserved) : base(message)
    {
    }
}
