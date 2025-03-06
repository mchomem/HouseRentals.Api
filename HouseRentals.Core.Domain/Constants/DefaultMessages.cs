namespace HouseRentals.Core.Domain.Constants;

public class DefaultMessages
{
    public const string TenantNotFound = "Tenant Not found.";
    public const string TenantMustBeAtLeast18YearsOld = "Tenant must be at least 18 years old.";

    public const string HouseNotFound = "House Not found.";
    public const string HouseReserved = "House is reserved.";
    public const string HouseAlreadyRented = "House is already rented.";
    public const string HouseMustBeReserved = "House must be reserved.";
    public const string HouseIsAlreadyReserved = "House is already reserved.";
    public const string HouseUnderMaintenance = "House under maintenance.";
    public const string HouseUnavailable = "House unavailable.";
    public const string HouseInvalidRentPrice = "House invalid Rent Price.";

    public const string RentalNotFound = "Rental not found.";
    public const string RentalInvalidDiscount = "Invalid discount.";
    public const string RentalDaysEqualsToZero = "Rental days must be greater than zero.";
}
