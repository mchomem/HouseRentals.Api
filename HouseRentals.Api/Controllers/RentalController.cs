namespace HouseRentals.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalController : ControllerBase
{
    private readonly IRentalService _rentalService;

    public RentalController(IRentalService rentalService)
        => _rentalService = rentalService;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] RentalFilter filter)
    {
        var rentals = await _rentalService.GetAllAsync(filter);

        if (!rentals.Any())
            return NotFound(new ApiResponse<IEnumerable<RentalDto>>(null!, "No rental found"));

        return Ok(new ApiResponse<IEnumerable<RentalDto>>(rentals));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        var rental = await _rentalService.GetAsync(id);

        if (rental is null)
            return NotFound(new ApiResponse<IEnumerable<RentalDto>>(null!, "No rental found"));

        return Ok(new ApiResponse<RentalDto>(rental));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RentalInsertDto rentalDto)
    {
        var rental = await _rentalService.CreateAsync(rentalDto);
        return Ok(new ApiResponse<RentalDto>(rental));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] RentalUpdateDto rentalDto)
    {
        var rental = await _rentalService.UpdateAsync(id, rentalDto);
        return Ok(new ApiResponse<RentalDto>(rental));
    }

    [HttpPut("rent")]
    public async Task<IActionResult> PutRentAsync([FromQuery] long id, [FromQuery] decimal discount)
    {
        var rental = await _rentalService.RentAsync(id, discount);
        return Ok(new ApiResponse<RentalDto>(rental));
    }

    [HttpPut("unrent/{id}")]
    public async Task<IActionResult> PutUnRentAsync(long id)
    {
        var rental = await _rentalService.UnRentAsync(id);
        return Ok(new ApiResponse<RentalDto>(rental));
    }
}
