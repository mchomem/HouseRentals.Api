using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentals.Database.Migrations
{
    /// <inheritdoc />
    public partial class Add_Columns_RentPaid_and_RentPaymentDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RentPaid",
                table: "Rental",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentPaymentDate",
                table: "Rental",
                type: "datetime",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentPaid",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "RentPaymentDate",
                table: "Rental");
        }
    }
}
