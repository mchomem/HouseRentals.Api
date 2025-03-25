namespace HouseRentals.Tests;

public class HouseUnitTest
{
    [Fact]
    public void Constructor_House_ReturnHouse()
    {
        // Arrange
        var address = "Avenue United, 1000";
        var dailyPrice = 100.00m;
        var numberOfRooms = 2;
        var description = "House close of montains.";
        var imageFileName = "image.png";

        // Act
        var house = new House(address, dailyPrice, numberOfRooms, description, imageFileName);

        // Assert
        Assert.Equal(house.Address, address);
        Assert.Equal(house.DailyPrice, dailyPrice);
        Assert.Equal(house.NumberOfRooms, numberOfRooms);
        Assert.Equal(house.Description, description);
        Assert.Equal(house.ImageFileName, imageFileName);
        Assert.False(house.Deleted);
        Assert.NotNull(house);
    }

    [Fact]
    public void Update_House_ReturnHouse()
    {
        // Arrange
        var house = new House("Avenue United, 1000", 100.00m, 2, "house close of montains", "image.png");
        var address = "Avenue United, 1000";
        var dailyPrice = 100.00m;
        var status = HouseStatus.Available;
        var numberOfRooms = 2;
        var description = "House close of montains.";
        var imageFileName = "image.png";

        // Act
        house.Update(address, dailyPrice, status, numberOfRooms, description, imageFileName);

        // Assert
        Assert.Equal(house.Address, address);
        Assert.Equal(house.DailyPrice, dailyPrice);
        Assert.Equal(house.NumberOfRooms, numberOfRooms);
        Assert.Equal(house.Description, description);
        Assert.Equal(house.ImageFileName, imageFileName);
    }

    [Fact]
    public void Delete_House_ShouldMarkAsDeleted()
    {
        // Arrange
        var house = new House("Avenue United, 1000", 100.00m, 2, "house close of montains", "image.png");

        // Act
        house.Delete();

        // Assert
        Assert.True(house.Deleted);
    }

    [Fact]
    public void UpdateRentPrice_SingleDecimal_ShouldUpdateRentPrice()
    {
        // Arrange
        var house = new House("Avenue United, 1000", 100.00m, 2, "house close of montains", "image.png");
        var newPrice = 10.00m;

        // Act
        house.UpdateRentPrice(newPrice);
        
        // Assert
        Assert.Equal(house.DailyPrice, newPrice);
    }

    [Fact]
    public void UpdateRentPrice_SingleDecimalZero_ShouldReturnHouseInvalidRentPrice()
    {
        // Arrange
        var house = new House("Avenue United, 1000", 100.00m, 2, "house close of montains", "image.png");
        var newPrice = 0.00m;

        // Assert & Act
        Assert.Throws<HouseInvalidRentPrice>(() =>
        {
            house.UpdateRentPrice(newPrice);
        });
    }

    [Fact]
    public void UpdateRentPrice_SingleDecimalMoreThan100_ShouldReturnHouseInvalidRentPrice()
    {
        // Arrange
        var house = new House("Avenue United, 1000", 100.00m, 2, "house close of montains", "image.png");
        var newPrice = 101.00m;

        // Assert & Act
        Assert.Throws<HouseInvalidRentPrice>(() =>
        {
            house.UpdateRentPrice(newPrice);
        });
    }
}
