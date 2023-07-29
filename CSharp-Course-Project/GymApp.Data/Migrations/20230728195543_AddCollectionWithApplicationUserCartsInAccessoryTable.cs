using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class AddCollectionWithApplicationUserCartsInAccessoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessoryId",
                table: "ApplicationUserCarts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCarts_AccessoryId",
                table: "ApplicationUserCarts",
                column: "AccessoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCarts_Accessories_AccessoryId",
                table: "ApplicationUserCarts",
                column: "AccessoryId",
                principalTable: "Accessories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCarts_Accessories_AccessoryId",
                table: "ApplicationUserCarts");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserCarts_AccessoryId",
                table: "ApplicationUserCarts");

            migrationBuilder.DropColumn(
                name: "AccessoryId",
                table: "ApplicationUserCarts");
        }
    }
}
