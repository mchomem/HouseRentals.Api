namespace HouseRentals.Database.Mappings;

public class HouseMapping : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder
            .ToTable("House")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Address)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(x => x.DailyPrice)
            .HasDefaultValueSql("0")
            .IsRequired();

        builder
            .Property(x => x.Status)
            .HasColumnType("varchar(40)")
            .IsRequired()
            .HasConversion<string>(); // A enumeração entra na base de dados com o valor textual e não com o seu valor númerico, isso facilita leitura e manutenção.

        builder
            .Property(x => x.NumberOfRooms)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder
            .Property(x => x.ImageFileName)
            .HasColumnType("varchar(50)")
            .IsRequired(false);

        builder
            .Property(x => x.Deleted)
            .HasColumnType("bit")
            .HasDefaultValueSql("0")
            .IsRequired();
    }
}
