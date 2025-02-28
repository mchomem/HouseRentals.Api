namespace HouseRentals.Core.Domain.Exceptions.House;

public class HouseReservedException : HouseException
{
    public HouseReservedException(string message = DefaultMessages.HouseReserved) : base(message)
    {
    }
}
