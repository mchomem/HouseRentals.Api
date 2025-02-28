namespace HouseRentals.Infrastructure.Persistence.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    public readonly DbSet<TEntity> _DbSet;
    public readonly AppDbContext _AppDbContext;

    public RepositoryBase(AppDbContext appDbContext)
    {
        _DbSet = appDbContext.Set<TEntity>();
        _AppDbContext = appDbContext;
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _DbSet.AddAsync(entity);
        await _AppDbContext.SaveChangesAsync();
        return _AppDbContext.Entry(entity).Entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _DbSet.Remove(entity);
        await _AppDbContext.SaveChangesAsync();
        return _AppDbContext.Entry(entity).Entity;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, string includes = "")
    {
        IQueryable<TEntity> query = _DbSet
            .AsQueryable()
            .AsNoTracking()
            .Where(filter);

        if (!string.IsNullOrEmpty(includes))
        {
            foreach (var include in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    public async Task<TEntity> GetAsync(long id)
    {
        var entity = await _DbSet.FindAsync(id);
        return entity!;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, string includes = "")
    {
        IQueryable<TEntity> query = _DbSet
                .AsQueryable()
                .Where(filter)
                .AsNoTracking();

        foreach (var include in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            query = query.Include(include);

        var entity = await query.FirstOrDefaultAsync();
        return entity!;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _DbSet.Update(entity);
        await _AppDbContext.SaveChangesAsync();
        return _AppDbContext.Entry(entity).Entity;
    }
}
