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
    public void SetStatus_HouseStatus_ShouldChangeStatusRented()
    {
        // Arrange
        var address = "Avenue United, 1000";
        var dailyPrice = 100.00m;
        var numberOfRooms = 2;
        var description = "House close of montains.";
        var imageFileName = "image.png";

        // Act
        var house = new House(address, dailyPrice, numberOfRooms, description, imageFileName);
        house.SetStatus(HouseStatus.Rented);

        // Assert
        Assert.Equal(HouseStatus.Rented, house.Status);
    }

    [Fact]
    public void SetStatus_HouseStatus_ReturnHouseException()
    {
        // Arrange
        var address = "Avenue United, 1000";
        var dailyPrice = 100.00m;
        var numberOfRooms = 2;
        var description = "House close of montains.";
        var imageFileName = "image.png";

        // Act & Assert
        var exception = Assert.Throws<HouseException>(() =>
        {
            var house = new House(address, dailyPrice, numberOfRooms, description, imageFileName);
            house.Update(address, dailyPrice, HouseStatus.Rented, numberOfRooms, description, imageFileName);
            house.SetStatus(HouseStatus.Available);
        });

        Assert.Equal(DefaultMessages.HouseMmustBeReserved, exception.Message);
    }

    // TODO: continuar com os testes de variações de House Status.
}
