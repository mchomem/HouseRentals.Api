namespace HouseRentals.Core.Application.Filters;

public class HouseFilter
{
    public string? Address { get; set; }
    public decimal? DailyPriceStart { get; set; }
    public decimal? DailyPriceEnd { get; set; }
    public HouseStatus? Status { get; set; }
    public int? NumberOfRoomsStart { get; set; }
    public int? NumberOfRoomsEnd { get; set; }
}
