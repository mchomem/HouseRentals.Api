namespace HouseRentals.Infrastructure.Persistence.Mappings;

public class RentalMapping : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.
            ToTable("Rental")
            .HasIndex(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.HouseId)
            .IsRequired();

        builder
            .Property(x => x.TenantId)
            .IsRequired();

        builder
            .Property(x => x.StartDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(x => x.EndDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(x => x.Discount)
            .HasColumnType("decimal(8,2)")
            .HasDefaultValueSql("0")
            .IsRequired();

        builder
            .Property(x => x.TotalPrice)
            .HasColumnType("decimal(8,2)")
            .HasDefaultValueSql("0")
            .IsRequired();

        builder
            .Property(x => x.TotalToPay)
            .HasColumnType("decimal(8,2)")
            .HasDefaultValueSql("0")
            .IsRequired();

        builder
            .Property(x => x.Observation)
            .HasColumnType("varchar(500)")
            .IsRequired(false);

        builder
            .Property(x => x.RentPaid)
            .HasColumnType("bit")
            .HasDefaultValueSql("0")
            .IsRequired();

        builder
            .Property(x => x.RentPaymentDate)
            .HasColumnType("datetime")
            .IsRequired(false);

        #region Foreign Key mapping for Rental table.

        builder
            .HasOne(r => r.House)
            .WithMany(h => h.Rentals)
            .HasForeignKey(r => r.HouseId)
            .HasConstraintName("FK_Rental_House_HouseId")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(r => r.Tenant)
            .WithMany(t => t.Rentals)
            .HasForeignKey(r => r.TenantId)
            .HasConstraintName("FK_Rental_Tenant_TenantId")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
