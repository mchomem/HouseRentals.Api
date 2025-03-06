namespace HouseRentals.Core.Domain.Entities;

/// <summary>
/// Representa uma casa disponível para aluguel.
/// </summary>
public class House : BaseEntity
{
    private House() { }

    public House(string address, decimal dailyPrice, int numberOfRooms, string description, string imageFileName)
    {
        Address = address;
        DailyPrice = dailyPrice;
        Status = HouseStatus.Available;
        NumberOfRooms = numberOfRooms;
        Description = description;
        ImageFileName = imageFileName;
    }

    public string Address { get; private set; }
    public decimal DailyPrice { get; private set; }
    public HouseStatus Status { get; private set; }
    public int NumberOfRooms { get; private set; }
    public string Description { get; private set; }
    public string ImageFileName { get; private set; }
    public bool Deleted { get; private set; }

    public ICollection<Rental> Rentals { get; private set; }

    public void Update(string address, decimal dailyPrice, HouseStatus status, int numberOfRooms, string description, string imageFileName)
    {
        Address = address;
        DailyPrice = dailyPrice;
        Status = status;
        NumberOfRooms = numberOfRooms;
        Description = description;
        ImageFileName = imageFileName;
    }

    public void Delete()
    {
        Deleted = true;
    }

    /// <summary>
    /// Atualiza o preço do aluguel.
    /// </summary>
    public void UpdateRentPrice(decimal newPrice)
    {
        if (newPrice < 0 || newPrice > 100)
            throw new HouseInvalidRentPrice();

        DailyPrice = newPrice;
    }

    /// <summary>
    /// Configura um estado da casa.
    /// </summary>
    public void SetStatus(HouseStatus status)
    {
        Status = status;
    }
}
