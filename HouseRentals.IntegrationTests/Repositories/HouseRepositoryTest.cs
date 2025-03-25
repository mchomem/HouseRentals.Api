namespace HouseRentals.IntegrationTests.Repositories;

public class HouseRepositoryTest : IDisposable
{
    private readonly AppDbContext _appDbContext;
    private readonly IRepositoryBase<House> _repositoryBase;
    private readonly HouseRepository _houseRepository;
    private bool _disposed = false;

    public HouseRepositoryTest()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
            .Options;

        _appDbContext = new AppDbContext(options);
        _repositoryBase = new RepositoryBase<House>(_appDbContext);
        _houseRepository = new HouseRepository(_repositoryBase);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _appDbContext.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task CreateAsync_SingleEntityHouse_ShouldReturnHouse()
    {
        // Arrange
        var house = new House(address: "John Smith, 132 My Street, Kingston, New York 12401", dailyPrice: 15.02m, numberOfRooms: 3, description: "a beautiful house", imageFileName: null!);

        // Act
        var result = await _houseRepository.CreateAsync(house);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().BeGreaterThan(0);

        var dbHouse = await _houseRepository.GetAsync(result.Id);
        dbHouse.Should().NotBeNull();
        dbHouse.Address.Should().Be(house.Address);
    }

    [Fact]
    public async Task GetAsync_SingleEntityHouse_ShouldReturnHouse()
    {
        // Arrange
        var house = new House(address: "John Smith, 132 My Street, Kingston, New York 12401", dailyPrice: 15.02m, numberOfRooms: 3, description: "a beautiful house", imageFileName: null!);
        await _houseRepository.CreateAsync(house);

        // Act
        var result = await _houseRepository.GetAsync(house.Id);

        // Assert
        result.Should().NotBeNull();
        result.DailyPrice.Should().Be(15.02m);
    }

    [Fact]
    public async Task GetAllAsync_EnumerableEntityHouse_ShouldReturnAllHouses()
    {
        // Arrange
        var house1 = new House(address: "John Smith, 132 My Street, Kingston, New York 12401", dailyPrice: 20.05m, numberOfRooms: 3, description: "a beautiful house", imageFileName: null!);
        var house2 = new House(address: "123 Maple Street, Springfield, IL 62704", dailyPrice: 15.02m, numberOfRooms: 2, description: "a beautiful house", imageFileName: null!);
        var house3 = new House(address: "456 Elm Avenue, Denver, CO 80202", dailyPrice: 18.50m, numberOfRooms: 1, description: "a beautiful house", imageFileName: null!);
        await _houseRepository.CreateAsync(house1);
        await _houseRepository.CreateAsync(house2);
        await _houseRepository.CreateAsync(house3);

        // Act
        var result = await _houseRepository.GetAllAsync(_ => true);

        // Assert
        result.Should().HaveCount(3);
    }

    [Fact]
    public async Task UpdateAsync_SingleEntityHouse_ShouldModifyHouse()
    {
        // Arrange
        var house = new House(address: "John Smith, 132 My Street, Kingston, New York 12401", dailyPrice: 20.30m, numberOfRooms: 3, description: "a beautiful house", imageFileName: null!);
        await _houseRepository.CreateAsync(house);

        // Act
        house.Update("101 Pine Road, Seattle, WA 98101", 15.02m, HouseStatus.Available, 2, "a beautiful house", null!);
        var result = await _houseRepository.UpdateAsync(house);

        // Assert
        result.Should().NotBeNull();
        result.DailyPrice.Should().Be(15.02m);
    }

    [Fact]
    public async Task DeleteAsync_SingleEntityHouse_ShouldReturnHouseLogicalDeleted()
    {
        // Arrange
        var house = new House(address: "John Smith, 132 My Street, Kingston, New York 12401", dailyPrice: 20.30m, numberOfRooms: 3, description: "a beautiful house", imageFileName: null!);
        await _houseRepository.CreateAsync(house);

        // Act
        house.Delete();
        await _houseRepository.UpdateAsync(house);

        // Assert
        var departmentLogicallyDeleted = await _houseRepository.GetAsync(house.Id);
        departmentLogicallyDeleted.Deleted.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteAsync_SingleEntityHouse_ShouldDeletedHouse()
    {
        // Arrange
        var house = new House(address: "John Smith, 132 My Street, Kingston, New York 12401", dailyPrice: 20.30m, numberOfRooms: 3, description: "a beautiful house", imageFileName: null!);
        await _houseRepository.CreateAsync(house);

        // Act
        await _houseRepository.DeleteAsync(house);

        // Assert
        var dbDepartment = await _houseRepository.GetAsync(house.Id);
        dbDepartment.Should().BeNull();
    }
}
