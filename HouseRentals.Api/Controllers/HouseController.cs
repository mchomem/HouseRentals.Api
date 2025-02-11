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
        IEnumerable<HouseDto> houses = await _houseService.GetAllAsync(filter);
        return Ok(houses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        var house = await _houseService.GetAsync(id);
        return Ok(house);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] HouseInsertDto houseDto)
    {
        var house = await _houseService.CreateAsync(houseDto);
        return Ok(house);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] HouseDto houseDto)
    {
        var house = await _houseService.UpdateAsync(id, houseDto);
        return Ok(house);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var house = await _houseService.DeleteAsync(id);
        return Ok(house);
    }
}
