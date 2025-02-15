namespace HouseRentals.Domain.Entities;

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
        => Deleted = true;

    /// <summary>
    /// Atualiza o preço do aluguel.
    /// </summary>
    public void UpdateRentPrice(decimal newPrice)
        => DailyPrice = newPrice;

    /// <summary>
    /// Configura um estado da casa.
    /// </summary>
    public void SetStatus(HouseStatus status)
    {
        CheckStatusTransicionRule(status);
        Status = status;
    }

    /// <summary>
    /// Quanto uma nova situação é informada,é vericado as possíveis combinações permitidas
    /// </summary>
    /// <param name="newStatus"></param>
    /// <exception cref="RentalException"></exception>
    private void CheckStatusTransicionRule(HouseStatus newStatus)
    {
        /*         
            Quando ocorre um registro de aluguel, o primeiro status é reservado

            Sequência cíclica de status permitidos:

            Disponível
            -> Reservado
            -> Alugado
            -> Em Manutenção
            -> Indisponível
            -> (volta a ser Disponível)
        */

        var currentHouseStatus = Status;

        switch (newStatus)
        {
            case HouseStatus.Available:
                switch (currentHouseStatus)
                {
                    case HouseStatus.Reserved:
                    case HouseStatus.UnderMaintenance:
                    case HouseStatus.Unavailable:
                        break;

                    case HouseStatus.Rented:
                        throw new HouseException(DefaultMessages.HouseMmustBeReserved);
                }
                break;

            case HouseStatus.Reserved:
                switch (currentHouseStatus)
                {
                    case HouseStatus.Rented:
                    case HouseStatus.Available:
                        break;

                    case HouseStatus.UnderMaintenance:
                    case HouseStatus.Unavailable:
                        throw new HouseException(DefaultMessages.HouseIsAlreadyReserved);
                }
                break;

            case HouseStatus.UnderMaintenance:
                switch (currentHouseStatus)
                {
                    case HouseStatus.Available:
                    case HouseStatus.Unavailable:
                        break;

                    case HouseStatus.Reserved:
                    case HouseStatus.Rented:
                        throw new HouseException(DefaultMessages.HouseUnderMaintenance);
                }
                break;

            case HouseStatus.Rented:
                //  Só é possível alugar a casa se a situação atual não for reservada,alugada, em manutenção ou indisponível.
                switch (currentHouseStatus)
                {
                    case HouseStatus.Available:
                    case HouseStatus.UnderMaintenance:
                        break;

                    case HouseStatus.Reserved:
                        throw new HouseException(DefaultMessages.HouseReserved);

                    case HouseStatus.Unavailable:
                        throw new HouseException(DefaultMessages.HouseUnavailable);
                }
                break;

            case HouseStatus.Unavailable:
                switch (currentHouseStatus)
                {
                    case HouseStatus.Available:
                    case HouseStatus.UnderMaintenance:
                        break;
                    case HouseStatus.Reserved:
                    case HouseStatus.Rented:
                        throw new HouseException(DefaultMessages.HouseUnavailable);
                }
                break;
        }
    }
}
