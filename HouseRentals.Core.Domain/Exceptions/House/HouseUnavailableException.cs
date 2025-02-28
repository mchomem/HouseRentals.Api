namespace HouseRentals.Core.Domain.Exceptions.House
{
    public class HouseUnavailableException : HouseException
    {
        public HouseUnavailableException(string message = DefaultMessages.HouseUnavailable) : base(message)
        {
        }
    }
}
