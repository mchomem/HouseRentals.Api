using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentals.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Column_Deleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Tenant",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Tenant");
        }
    }
}
