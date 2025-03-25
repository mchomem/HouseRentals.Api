namespace HouseRentals.IntegrationTests.Repositories;

public class TenantRepositoryTest : IDisposable
{
    private readonly AppDbContext _appDbContext;
    private readonly IRepositoryBase<Tenant> _repositoryBase;
    private readonly TenantRepository _tenantRepository;
    private bool _disposed = false;

    public TenantRepositoryTest()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
            .Options;

        _appDbContext = new AppDbContext(options);
        _repositoryBase = new RepositoryBase<Tenant>(_appDbContext);
        _tenantRepository = new TenantRepository(_repositoryBase);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _appDbContext.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // TODO: finalizar os métodos.
}
