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
    public async Task<IActionResult> PostAsync(TenantInsertDto tenantDto)
    {
        var tenant = await _tenantService.CreateAsync(tenantDto);
        return Ok(tenant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, TenantDto tenantDto)
    {
        var tenant = await _tenantService.UpdateAsync(id, tenantDto);
        return Ok(tenant);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var tenant = await _tenantService.DeleteAsync(id);
        return Ok(tenant);
    }        
}
