using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class AddingProfilePictureProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Quantity",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Quantity",
                value: 0);
        }
    }
}
