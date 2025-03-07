namespace HouseRentals.Core.Domain.Entities;

/// <summary>
/// Representa o aluguel de uma casa.
/// </summary>
public class Rental : BaseEntity
{
    private Rental() { }

    public Rental(long houseId, House house, long tenantId, Tenant tenant, DateTime startDate, DateTime endDate, string observation)
    {
        HouseId = houseId;
        House = house;
        House.SetStatus(HouseStatus.Reserved);
        TenantId = tenantId;
        Tenant = tenant;
        StartDate = startDate;
        EndDate = endDate;
        CheckIfDaysAreGreaterThanZero();
        Discount = 0;
        TotalPrice = 0;
        TotalToPay = 0;
        Observation = observation;
    }

    public long HouseId { get; private set; }
    public House House { get; private set; }
    public long TenantId { get; private set; }
    public Tenant Tenant { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal Discount { get; private set; }
    public decimal TotalPrice { get; private set; }
    public decimal TotalToPay { get; private set; }
    public string Observation { get; private set; }
    public bool RentPaid { get; private set; }
    public DateTime? RentPaymentDate { get; private set; }

    public void Update(long houseId, House house, long tenantId, Tenant tenant, DateTime startDate, DateTime endDate, decimal discount, string observation)
    {
        HouseId = houseId;
        House = house;
        House.SetStatus(HouseStatus.Rented);
        TenantId = tenantId;
        Tenant = tenant;
        StartDate = startDate;
        EndDate = endDate;
        CheckIfDaysAreGreaterThanZero();
        Discount = CheckDiscount(discount);
        TotalPrice = CalculateTotalPrice();
        TotalToPay = TotalPrice - (TotalPrice * Discount / 100);
        Observation = observation;
    }

    /// <summary>
    /// Calcula o preço total com base na duração do aluguel.
    /// </summary>
    public decimal CalculateTotalPrice()
    {
        CheckIfDaysAreGreaterThanZero();

        var days = (EndDate - StartDate).Days;

        return days * House.DailyPrice;
    }
    
    public void CheckIfDaysAreGreaterThanZero()
    {
        var days = (EndDate - StartDate).Days;

        if (days == 0)
            throw new RentalDaysEqualToZeroException();
    }

    /// <summary>
    /// Verifica se o desconto é válido.
    /// </summary>
    /// <param name="discount"></param>
    /// <returns></returns>
    /// <exception cref="RentalInvalidDiscountException"></exception>
    public decimal CheckDiscount(decimal discount)
    {
        if (discount < 0 || discount > 100)
            throw new RentalInvalidDiscountException();

        return discount;
    }

    public void Rent(decimal discount, Tenant rentedTenant, Tenant informedTenant)
    {
        var sameTenant = CheckIfSameTenant(rentedTenant, informedTenant);
        CheckHouseStatusTransicionRule(HouseStatus.Rented, sameTenant);
        House.SetStatus(HouseStatus.Rented);
        Discount = CheckDiscount(discount);
        TotalPrice = CalculateTotalPrice();
        TotalToPay = TotalPrice - (TotalPrice * Discount / 100);
    }

    public void ToMakeUnavailable()
    {
        House.SetStatus(HouseStatus.Unavailable);
    }

    public void ToMakeAvailable()
    {
        House.SetStatus(HouseStatus.Available);
    }

    /// <summary>
    /// Faz o encerramento do serviço de aluguel, deixando a casa em manutenção.
    /// </summary>
    public void UnRent()
    {
        RentPaid = true;
        RentPaymentDate = DateTime.UtcNow;
        House.SetStatus(HouseStatus.UnderMaintenance);
    }

    public bool CheckIfSameTenant(Tenant rentedTenant, Tenant informedTenant)
    {
        return rentedTenant.Id == informedTenant.Id;
    }

    /// <summary>
    /// Quanto uma nova situação é informada para uma casa, são vericados as possíveis combinações permitidas
    /// </summary>
    /// <param name="newStatus"></param>
    /// <exception cref="RentalException"></exception>
    public void CheckHouseStatusTransicionRule(HouseStatus newStatus, bool sameTenant)
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

        var currentHouseStatus = House.Status;

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
                        throw new HouseMustBeReservedException();
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
                        throw new HouseIsAlreadyReservedException();
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
                        throw new HouseUnderMaintenanceException();
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
                        if (!sameTenant)
                            throw new HouseReservedException();
                        else
                            break;

                    case HouseStatus.Unavailable:
                        throw new HouseUnavailableException();
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
                        throw new HouseUnavailableException();
                }
                break;
        }
    }
}
