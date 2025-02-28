namespace HouseRentals.Core.Application.DTOs;

public class HouseDto
{
    public long Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public decimal DailyPrice { get; set; }
    public HouseStatus Status { get; set; }
    public int NumberOfRooms { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageFileName { get; set; } = string.Empty;
    public bool Deleted { get; set; }
}

public class HouseInsertDto
{
    public string Address { get; set; } = string.Empty;
    public decimal DailyPrice { get; set; }
    public HouseStatus Status { get; set; }
    public int NumberOfRooms { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? ImageFileName { get; set; }
}