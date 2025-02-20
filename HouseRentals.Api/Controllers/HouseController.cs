namespace HouseRentals.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HouseController : ControllerBase
{
    private readonly IHouseService _houseService;

    public HouseController(IHouseService houseService)
        => _houseService = houseService;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] HouseFilter filter)
    {
        var houses = await _houseService.GetAllAsync(filter);

        if (!houses.Any())
            return NotFound(new ApiResponse<IEnumerable<HouseDto>>(null!, "No house found"));

        return Ok(new ApiResponse<IEnumerable<HouseDto>>(houses));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        var house = await _houseService.GetAsync(id);

        if (house is null)
            return NotFound(new ApiResponse<IEnumerable<HouseDto>>(null!, "No house found"));

        return Ok(new ApiResponse<HouseDto>(house));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] HouseInsertDto houseDto)
    {
        var house = await _houseService.CreateAsync(houseDto);
        return Ok(new ApiResponse<HouseDto>(house));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] HouseDto houseDto)
    {
        var house = await _houseService.UpdateAsync(id, houseDto);
        return Ok(new ApiResponse<HouseDto>(house));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var house = await _houseService.DeleteAsync(id);
        return Ok(new ApiResponse<HouseDto>(house));
    }
}
