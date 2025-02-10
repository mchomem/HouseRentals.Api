namespace HouseRentals.Domain.Entities;

/// <summary>
/// Representa uma casa disponível para aluguel.
/// </summary>
public class House : BaseEntity
{
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

    public void Update(string address, decimal rentPrice, HouseStatus status, int numberOfRooms, string description, string imageFileName)
    {
        Address = address;
        DailyPrice = rentPrice;
        Status = status;
        NumberOfRooms = numberOfRooms;
        Description = description;
        ImageFileName = imageFileName;
    }

    public void Delete()
        => Deleted = true;

    /// <summary>
    /// Atualiza o preço do aluguel.
    /// </summary>
    public void UpdateRentPrice(decimal newPrice)
        => DailyPrice = newPrice;

    /// <summary>
    /// Configura um estado da casa e verificar o estado atual.
    /// </summary>
    public void SetStatus(HouseStatus status)
    {
        switch (status)
        {
            case HouseStatus.Available:
                break;

            case HouseStatus.Reserved:
                break;

            case HouseStatus.UnderMaintenance:
                break;

            case HouseStatus.Rented:
                //  A única situação que permite alugar uma casa é disponível
                switch (Status)
                {
                    case HouseStatus.Reserved:
                        throw new RentalException(DefaultMessages.HouseReserved);

                    case HouseStatus.Rented:
                        throw new RentalException(DefaultMessages.HouseAlreadyRented);

                    case HouseStatus.UnderMaintenance:
                        throw new RentalException(DefaultMessages.HouseUnderMaintenance);

                    case HouseStatus.Unavailable:
                        throw new RentalException(DefaultMessages.HouseUnavailable);

                    case HouseStatus.Deleted: // Se no filtro não é exibido os registros deletados, será é necessário essa verificação?
                        throw new RentalException(DefaultMessages.HouseDeleted);
                }
                break;

            case HouseStatus.Unavailable:
                break;

            case HouseStatus.Deleted:
                break;
        }

        Status = status;
    }
}
