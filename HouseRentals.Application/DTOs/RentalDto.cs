namespace HouseRentals.Application.DTOs;

public class RentalDto
{
    public long Id { get; set; }
    public long HouseId { get; set; }
    public HouseDto House { get; set; }
    public long TenantId { get; set; }
    public TenantDto Tenant { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalToPay { get; set; }
    public string Observation { get; set; } = string.Empty;
    public bool RentPaid { get; set; }
    public DateTime? RentPaymentDate { get;  set; }
}

public class RentalInsertDto
{
    public long HouseId { get; set; }
    public long TenantId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Discount { get; set; }
    public string? Observation { get; set; }
}

public class RentalUpdateDto
{
    public long Id { get; set; }
    public long HouseId { get; set; }
    public long TenantId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Discount { get; set; }
    public string? Observation { get; set; }
}
