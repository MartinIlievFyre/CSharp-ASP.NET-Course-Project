using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class ChangeLinksForImagesForClothes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://www.hard-wear.com/media/catalog/product/cache/b8bf61042c9b806ea0edf19101a0211e/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://www.hard-wear.com/media/catalog/product/cache/b8bf61042c9b806ea0edf19101a0211e/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://www.hard-wear.com/media/catalog/product/cache/b8bf61042c9b806ea0edf19101a0211e/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg");

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "Color", "Description", "Fabric", "ImageUrl", "Name", "Price", "Size", "WearCategoryId" },
                values: new object[,]
                {
                    { 16, "White", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "Cutton", "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-Hardcore-Sportswear-Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg", "Hardcore Hoodie White", 29.99m, "S", 2 },
                    { 17, "White", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "Cutton", "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-Hardcore-Sportswear-Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg", "Hardcore Hoodie White", 29.99m, "M", 2 },
                    { 18, "White", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "Cutton", "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-Hardcore-Sportswear-Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg", "Hardcore Hoodie White", 29.99m, "L", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://100procenthardcore.com/wp-content/uploads/2023/05/100-Hardcore-Hooded-Logo-/Gabber-4Life- Black-301-S14-050-1.jpg");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://100procenthardcore.com/wp-content/uploads/2023/05/100-Hardcore-Hooded-Logo-/Gabber-4Life- Black-301-S14-050-1.jpg");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://100procenthardcore.com/wp-content/uploads/2023/05/100-Hardcore-Hooded-Logo-/Gabber-4Life- Black-301-S14-050-1.jpg");
        }
    }
}
