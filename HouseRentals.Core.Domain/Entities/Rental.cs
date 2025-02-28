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
        var days = (EndDate - StartDate).Days;
        return days * House.DailyPrice;
    }

    /// <summary>
    /// Verifica se o desconto é válido.
    /// </summary>
    /// <param name="discount"></param>
    /// <returns></returns>
    /// <exception cref="RentalException"></exception>
    public decimal CheckDiscount(decimal discount)
    {
        if (discount < 0 || discount > 100)
            throw new RentalInvalidDiscountException();

        return discount;
    }

    public void Rent(decimal discount)
    {
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
}
