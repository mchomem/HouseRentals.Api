namespace HouseRentals.Domain.Entities;

/// <summary>
/// Representa o aluguel de uma casa.
/// </summary>
public class Rental : BaseEntity
{
    public Rental(long houseId, House house, long tenantId, Tenant tenant, DateTime startDate, DateTime endDate, decimal discount, string observation)
    {
        HouseId = houseId;
        House = house;
        House.SetStatus(HouseStatus.Rented);
        TenantId = tenantId;
        Tenant = tenant;
        StartDate = startDate;
        EndDate = endDate;
        Discount = SetDiscount(discount);
        TotalPrice = CalculateTotalPrice();
        TotalToPay = TotalPrice - (TotalPrice * Discount / 100);
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

    /// <summary>
    /// Calcula o preço total com base na duração do aluguel.
    /// </summary>
    private decimal CalculateTotalPrice()
    {
        var days = (EndDate - StartDate).Days;
        return days * House.DailyPrice;
    }

    private decimal SetDiscount(decimal discount)
    {
        if (discount < 0 || discount > 100)
            throw new RentalException(DefaultMessages.RentalInvalidDiscount);

        return discount;
    }
}
