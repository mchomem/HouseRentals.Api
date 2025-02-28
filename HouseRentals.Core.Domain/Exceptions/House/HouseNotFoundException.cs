namespace HouseRentals.Core.Domain.Exceptions.House;

public class HouseNotFoundException : HouseException
{
    public HouseNotFoundException(string message = DefaultMessages.HouseNotFound) : base(message)
    {
    }
}
