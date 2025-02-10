using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentals.Database.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_House : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "0"),
                    Status = table.Column<string>(type: "varchar(40)", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageFileName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "House");
        }
    }
}
