namespace HouseRentals.Domain.Exceptions.House;

internal class HouseIsAlreadyRentedException : HouseException
{
    public HouseIsAlreadyRentedException(string message = DefaultMessages.HouseAlreadyRented) : base(message)
    {
    }
}
