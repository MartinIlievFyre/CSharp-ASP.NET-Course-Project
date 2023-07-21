using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class ChangedPriceOfJustWheySupplement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 99.99m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 9.99m);
        }
    }
}
