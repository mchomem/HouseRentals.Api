namespace HouseRentals.Api.Entities;

/// <summary>
/// Representa uma casa disponível para aluguel.
/// </summary>
public class House : BaseEntity
{
    public House(string address, decimal rentPrice, int numberOfRooms, string description, string imageFileName)
    {
        Address = address;
        RentPrice = rentPrice;
        NumberOfRooms = numberOfRooms;
        Description = description;
        ImageFileName = imageFileName;
        IsAvailable = true;
    }

    public string Address { get; private set; }
    public decimal RentPrice { get; private set; }
    public bool IsAvailable { get; private set; }
    public int NumberOfRooms { get; private set; }
    public string Description { get; private set; }
    public string ImageFileName { get; private set; }

    /// <summary>
    /// Atualiza o preço do aluguel.
    /// </summary>
    public void UpdateRentPrice(decimal newPrice)
    {
        RentPrice = newPrice;
    }

    /// <summary>
    /// Marca a casa como alugada ou disponível.
    /// </summary>
    public void SetAvailability(bool availability)
    {
        IsAvailable = availability;
    }
}
