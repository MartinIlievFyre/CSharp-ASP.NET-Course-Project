using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class SeedingDataInWearAndWearCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersFoods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "WearCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WearCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    WearCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothes_WearCategories_WearCategoryId",
                        column: x => x.WearCategoryId,
                        principalTable: "WearCategories",
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

            migrationBuilder.InsertData(
                table: "WearCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "T-Shirts" });

            migrationBuilder.InsertData(
                table: "WearCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Hoodies" });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "Color", "Description", "ImageUrl", "Name", "Price", "Size", "WearCategoryId" },
                values: new object[,]
                {
                    { 1, "Black", "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.", "https://100procenthardcore.ams3.digitaloceanspaces.com/wp-content/ uploads/2023/2023/05/29213518/305-B01-050-voor.jpeg", "Hardcore T-shirt Black", 29.99m, "S", 1 },
                    { 2, "Black", "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.", "https://100procenthardcore.ams3.digitaloceanspaces.com/wp-content/ uploads/2023/2023/05/29213518/305-B01-050-voor.jpeg", "Hardcore T-shirt Black", 29.99m, "M", 1 },
                    { 3, "Black", "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.", "https://100procenthardcore.ams3.digitaloceanspaces.com/wp-content/ uploads/2023/2023/05/29213518/305-B01-050-voor.jpeg", "Hardcore T-shirt Black", 29.99m, "L", 1 },
                    { 4, "White", "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.", "https://100procenthardcore.com/wp-content/uploads/2023/05/305-B01-100-100-Hardcore-T-Shirt-Wear- It-With-Pride-Wit-1.jpg", "Hardcore T-shirt White", 29.99m, "S", 1 },
                    { 5, "White", "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.", "https://100procenthardcore.com/wp-content/uploads/2023/05/305-B01-100-100-Hardcore-T-Shirt-Wear- It-With-Pride-Wit-1.jpg", "Hardcore T-shirt White", 29.99m, "M", 1 },
                    { 6, "White", "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.", "https://100procenthardcore.com/wp-content/uploads/2023/05/305-B01-100-100-Hardcore-T-Shirt-Wear- It-With-Pride-Wit-1.jpg", "Hardcore T-shirt White", 29.99m, "L", 1 },
                    { 7, "Black", "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range /o  motion to get you through your workout in total comfort.", "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg? width=800&height=800&hash=1600", "Gym Warrior T-shirt Black", 29.99m, "S", 1 },
                    { 8, "Black", "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range /o  motion to get you through your workout in total comfort.", "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg? width=800&height=800&hash=1600", "Gym Warrior T-shirt Black", 29.99m, "M", 1 },
                    { 9, "Black", "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range /o  motion to get you through your workout in total comfort.", "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg? width=800&height=800&hash=1600", "Gym Warrior T-shirt Black", 29.99m, "L", 1 },
                    { 10, "Black", "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range of motion  to get you through your workout in total comfort.", "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeat-t- shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit", "The Cicle T-shirt Black", 29.99m, "S", 1 },
                    { 11, "Black", "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range of motion  to get you through your workout in total comfort.", "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeat-t- shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit", "The Cicle T-shirt Black", 29.99m, "M", 1 },
                    { 12, "Black", "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range of motion  to get you through your workout in total comfort.", "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeat-t- shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit", "The Cicle T-shirt Black", 29.99m, "L", 1 },
                    { 13, "Black", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "https://100procenthardcore.com/wp-content/uploads/2023/05/100-Hardcore-Hooded-Logo-/Gabber-4Life- Black-301-S14-050-1.jpg", "Hardcore Hoodie Black", 29.99m, "S", 2 },
                    { 14, "Black", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "https://100procenthardcore.com/wp-content/uploads/2023/05/100-Hardcore-Hooded-Logo-/Gabber-4Life- Black-301-S14-050-1.jpg", "Hardcore Hoodie Black", 29.99m, "M", 2 },
                    { 15, "Black", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "https://100procenthardcore.com/wp-content/uploads/2023/05/100-Hardcore-Hooded-Logo-/Gabber-4Life- Black-301-S14-050-1.jpg", "Hardcore Hoodie Black", 29.99m, "L", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersClothes_WearId",
                table: "ApplicationUsersClothes",
                column: "WearId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_WearCategoryId",
                table: "Clothes",
                column: "WearCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsersClothes");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "WearCategories");

            migrationBuilder.InsertData(
                table: "UsersFoods",
                columns: new[] { "Id", "Calories", "Carbs", "Fat", "Grams", "Name", "Protein" },
                values: new object[] { 2, 153, 0.0, 3.6000000000000001, 0, "Chicken Fillet", 30.199999999999999 });
        }
    }
}
