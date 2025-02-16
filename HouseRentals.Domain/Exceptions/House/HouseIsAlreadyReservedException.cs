namespace HouseRentals.Domain.Exceptions.House;

public class HouseIsAlreadyReservedException : HouseException
{
    public HouseIsAlreadyReservedException(string message = DefaultMessages.HouseIsAlreadyReserved) : base(message)
    {
    }
}
