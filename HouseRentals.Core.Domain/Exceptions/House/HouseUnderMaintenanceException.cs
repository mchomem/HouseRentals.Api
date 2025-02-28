namespace HouseRentals.Core.Domain.Exceptions.House;

public class HouseUnderMaintenanceException : HouseException
{
    public HouseUnderMaintenanceException(string message = DefaultMessages.HouseUnderMaintenance) : base(message)
    {
    }
}
