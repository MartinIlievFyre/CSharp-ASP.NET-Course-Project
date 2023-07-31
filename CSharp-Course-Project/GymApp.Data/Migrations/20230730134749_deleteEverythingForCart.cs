using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class deleteEverythingForCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoryCartItems");

            migrationBuilder.DropTable(
                name: "ApplicationUserAccessories");

            migrationBuilder.DropTable(
                name: "ApplicationUserCarts");

            migrationBuilder.DropTable(
                name: "ApplicationUsersClothes");

            migrationBuilder.DropTable(
                name: "ApplicationUserSupplements");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "SupplementCartItems");

            migrationBuilder.DropTable(
                name: "WearCartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Accessories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Accessories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationUserAccessories",
                columns: table => new
                {
                    TrainingGuyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserAccessories", x => new { x.TrainingGuyId, x.AccessoryId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserAccessories_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserAccessories_AspNetUsers_TrainingGuyId",
                        column: x => x.TrainingGuyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsersClothes",
                columns: table => new
                {
                    TrainingGuyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersClothes", x => new { x.TrainingGuyId, x.WearId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersClothes_AspNetUsers_TrainingGuyId",
                        column: x => x.TrainingGuyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersClothes_Clothes_WearId",
                        column: x => x.WearId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessoryCartItems",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryCartItems", x => new { x.CartId, x.AccessoryId });
                    table.ForeignKey(
                        name: "FK_AccessoryCartItems_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessoryCartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserCarts",
                columns: table => new
                {
                    TrainingGuyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserCarts", x => new { x.TrainingGuyId, x.CartId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserCarts_AspNetUsers_TrainingGuyId",
                        column: x => x.TrainingGuyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplementCartItems",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplementId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementCartItems", x => new { x.CartId, x.SupplementId });
                    table.ForeignKey(
                        name: "FK_SupplementCartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplementCartItems_Supplements_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Supplements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WearCartItems",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WearId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WearCartItems", x => new { x.CartId, x.WearId });
                    table.ForeignKey(
                        name: "FK_WearCartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WearCartItems_Clothes_WearId",
                        column: x => x.WearId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryCartItems_AccessoryId",
                table: "AccessoryCartItems",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserAccessories_AccessoryId",
                table: "ApplicationUserAccessories",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCarts_CartId",
                table: "ApplicationUserCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersClothes_WearId",
                table: "ApplicationUsersClothes",
                column: "WearId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSupplements_SupplementId",
                table: "ApplicationUserSupplements",
                column: "SupplementId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplementCartItems_SupplementId",
                table: "SupplementCartItems",
                column: "SupplementId");

            migrationBuilder.CreateIndex(
                name: "IX_WearCartItems_WearId",
                table: "WearCartItems",
                column: "WearId");
        }
    }
}
