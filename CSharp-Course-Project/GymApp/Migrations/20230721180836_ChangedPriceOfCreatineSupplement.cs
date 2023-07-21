using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class ChangedPriceOfCreatineSupplement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 39.99m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 9.99m);
        }
    }
}
