using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentals.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Change_FK_Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rental_House",
                table: "Rental");

            migrationBuilder.DropForeignKey(
                name: "FK_Rental_Tenant",
                table: "Rental");

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_House_HouseId",
                table: "Rental",
                column: "HouseId",
                principalTable: "House",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_Tenant_TenantId",
                table: "Rental",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rental_House_HouseId",
                table: "Rental");

            migrationBuilder.DropForeignKey(
                name: "FK_Rental_Tenant_TenantId",
                table: "Rental");

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_House",
                table: "Rental",
                column: "HouseId",
                principalTable: "House",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_Tenant",
                table: "Rental",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id");
        }
    }
}
