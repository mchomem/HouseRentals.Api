namespace HouseRentals.Domain.Entities;

/// <summary>
/// Representa o aluguel de uma casa.
/// </summary>
public class Rental : BaseEntity
{
    public Rental(House house, Tenant tenant, DateTime startDate, DateTime endDate)
    {
        House = house;
        Tenant = tenant;
        StartDate = startDate;
        EndDate = endDate;
        TotalPrice = CalculateTotalPrice();
    }

    public Guid HouseId { get; private set; }
    public House House { get; private set; }
    public Guid TenantId { get; private set; }
    public Tenant Tenant { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal Discount { get; private set; }
    public decimal TotalPrice { get; private set; }

    /// <summary>
    /// Calcula o preço total com base na duração do aluguel.
    /// </summary>
    private decimal CalculateTotalPrice()
    {
        var days = (EndDate - StartDate).Days;
        return days * House.RentPrice;
    }
}
