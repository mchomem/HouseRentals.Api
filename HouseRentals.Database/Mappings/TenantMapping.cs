namespace HouseRentals.Database.Mappings;

public class TenantMapping : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder
            .ToTable("Tenant")
            .HasKey(t => t.Id);

        builder
            .Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(t => t.FullName)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(t => t.Email)
            .HasColumnType("varchar(40)")
            .IsRequired();
        
        builder
            .Property(t => t.PhoneNumber)
            .HasColumnType("char(11)")
            .IsRequired();

        builder
            .Property(t => t.BirthDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(t => t.Deleted)
            .HasColumnType("bit")
            .HasDefaultValueSql("0")
            .IsRequired();
    }
}
