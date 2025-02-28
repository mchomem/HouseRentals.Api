namespace HouseRentals.Core.Application.Filters;

public class RentalFilter
{
    public long? HouseId { get; set; }
    public long? TenantId { get; set; }
    public DateTime? StartDateStart { get; set; }
    public DateTime? StartDateEnd { get; set; }
    public DateTime? EndDateStart { get; set; }
    public DateTime? EndDateEnd { get; set; }
    public decimal? DiscountStart { get; set; }
    public decimal? DiscountEnd { get; set; }
    public decimal? TotalPriceStart { get; set; }
    public decimal? TotalPriceEnd { get; set; }
    public decimal? TotalToPayStart { get; set; }
    public decimal? TotalToPayEnd { get; set; }
    public string? Observation { get; set; }
    public bool? RentPaid { get; set; }
    public DateTime? RentPaymentDateStart { get; set; }
    public DateTime? RentPaymentDateEnd { get; set; }
}
