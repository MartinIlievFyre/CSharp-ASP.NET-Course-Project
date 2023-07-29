using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class AddProductsForCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ApplicationUserSupplements",
                columns: table => new
                {
                    TrainingGuyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserSupplements", x => new { x.TrainingGuyId, x.SupplementId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserSupplements_AspNetUsers_TrainingGuyId",
                        column: x => x.TrainingGuyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSupplements_Supplements_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Supplements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSupplements_SupplementId",
                table: "ApplicationUserSupplements",
                column: "SupplementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserSupplements");

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
    }
}
