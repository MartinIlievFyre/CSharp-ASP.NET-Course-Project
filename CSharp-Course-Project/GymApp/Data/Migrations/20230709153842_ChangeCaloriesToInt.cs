using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class ChangeCaloriesToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Calories",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "Calories",
                value: 52);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "Calories",
                value: 153);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Calories",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "Calories",
                value: 52.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "Calories",
                value: 153.0);
        }
    }
}
