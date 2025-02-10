using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentals.Database.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_Rental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<long>(type: "bigint", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValueSql: "0"),
                    TotalPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValueSql: "0"),
                    TotalToPay = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValueSql: "0"),
                    Observation = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rental_House",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rental_Tenant",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_HouseId",
                table: "Rental",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_Id",
                table: "Rental",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_TenantId",
                table: "Rental",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");
        }
    }
}
