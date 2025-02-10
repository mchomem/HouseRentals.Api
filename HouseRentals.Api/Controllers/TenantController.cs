namespace HouseRentals.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TenantController : ControllerBase
{
    private readonly ITenantService _tenantService;

    public TenantController(ITenantService tenantService)
        => _tenantService = tenantService;

    [HttpGet]
    public async Task<IActionResult> GetAlAsync([FromQuery] TenantFilter filter)
    {
        var tenants = await _tenantService.GetAllAsync(filter);
        return Ok(tenants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsyn(long id)
    {
        var tenant = await _tenantService.GetAsync(id);
        return Ok(tenant);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(TenantDto tenantDto)
        => Ok(await _tenantService.CreateAsync(tenantDto));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, TenantDto tenantDto)
        => Ok(await _tenantService.UpdateAsync(id, tenantDto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _tenantService.DeleteAsync(id));
}
