namespace HouseRentals.Tests;

public class RentalUnitTest
{
    [Fact]
    public void CheckDiscount_DecimalValue_ReturnDecimal()
    {
        // Arrange
        var tenant = new Tenant("John Walker", "john.walker@email.com", "51999999999", DateTime.Today.AddYears(-20));
        var house = new House("Street Write, 1000", 100.00m, 3, "House close of montains", "house.png");
        var startRentalDate = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc);
        var endRentalDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc);
        var rental = new Rental(1, house, 1, tenant, startRentalDate, endRentalDate, "Nothing");
        var discount = 10.00m;

        // Act
        rental.CheckDiscount(discount);

        // Assert
        Assert.Equal(10, discount);
    }

    [Fact]
    public void CheckDiscount_DecimalValue_ReturnRentalInvalidDiscountException()
    {
        // Arrange
        var tenant = new Tenant("John Walker", "john.walker@email.com", "51999999999", DateTime.Today.AddYears(-20));
        var house = new House("Street Write, 1000", 100.00m, 3, "House close of montains", "house.png");
        var startRentalDate = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc);
        var endRentalDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc);
        var rental = new Rental(1, house, 1, tenant, startRentalDate, endRentalDate, "Nothing");

        // Act & Assert
        Assert.Throws<RentalInvalidDiscountException>(() =>
        {
            rental.CheckDiscount(-10);
        });
    }

    [Fact]
    public void SetStatus_HouseStatus_ShouldChangeStatusRented()
    {
        // Arrange
        var house = new House("Street Write, 1000", 100.00m, 3, "House close of montains", "house.png");
        var tenant = new Tenant("John Walker", "john.walker@email.com", "51999999999", DateTime.Today.AddYears(-20));
        var rental = new Rental(1, house, 1, tenant, DateTime.Today, DateTime.Today.AddDays(10), "Nothing");

        // Act
        rental.Update(1, house, 1, tenant, DateTime.Today, DateTime.Today.AddDays(10), 0, "Nothing");

        // Assert
        Assert.Equal(HouseStatus.Rented, house.Status);
    }

    [Fact]
    public void SetStatus_HouseStatus_ShouldChangeStatusAvailable()
    {
        // Arrange
        var house = new House("Street Write, 1000", 100.00m, 3, "House close of montains", "house.png");
        var tenant = new Tenant("John Walker", "john.walker@email.com", "51999999999", DateTime.Today.AddYears(-20));
        var rental = new Rental(1, house, 1, tenant, DateTime.Today, DateTime.Today.AddDays(10), "Nothing");

        // Act
        rental.Update(1, house, 1, tenant, DateTime.Today, DateTime.Today.AddDays(10), 0, "Nothing");
        rental.ToMakeAvailable();

        // Assert
        Assert.Equal(HouseStatus.Available, house.Status);
    }
}
