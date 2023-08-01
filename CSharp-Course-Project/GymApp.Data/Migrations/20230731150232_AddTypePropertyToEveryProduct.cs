using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class AddTypePropertyToEveryProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Supplements",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Clothes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Accessories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Accessory");

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Accessory");

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Accessory");

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "Accessory");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Wear");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Wear");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Wear");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "Wear");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: "Wear");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: "Wear");

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Supplement");

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Supplement");

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Supplement");

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "Supplement");

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: "Supplement");

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: "Supplement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Accessories");
        }
    }
}
