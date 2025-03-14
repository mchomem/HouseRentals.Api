﻿namespace HouseRentals.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    DbSet<Tenant> Tenant { get; set; }
    DbSet<House> House { get; set; }
    DbSet<Rental> Rental { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantMapping).Assembly);
}
