namespace HouseRentals.Infrastructure.Persistence.Mappings;

public class TenantMapping : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder
            .ToTable("Tenant")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.FullName)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(x => x.Email)
            .HasColumnType("varchar(40)")
            .IsRequired();
        
        builder
            .Property(x => x.PhoneNumber)
            .HasColumnType("char(11)")
            .IsRequired();

        builder
            .Property(x => x.BirthDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(x => x.Deleted)
            .HasColumnType("bit")
            .HasDefaultValueSql("0")
            .IsRequired();
    }
}
