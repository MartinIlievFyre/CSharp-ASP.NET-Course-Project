using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class ChangeCaloriesCarbsFatProteinFromIntToDoubleAndSeedDatabaseWithFoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Protein",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Fat",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Carbs",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Calories",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Calories", "Carbs", "Fat", "Name", "Protein" },
                values: new object[] { 1, 52.0, 13.800000000000001, 0.20000000000000001, "Apple", 0.29999999999999999 });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Calories", "Fat", "Name", "Protein" },
                values: new object[] { 2, 153.0, 3.6000000000000001, "Chicken Fillet", 30.199999999999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Protein",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Fat",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Carbs",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Calories",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);
        }
    }
}
