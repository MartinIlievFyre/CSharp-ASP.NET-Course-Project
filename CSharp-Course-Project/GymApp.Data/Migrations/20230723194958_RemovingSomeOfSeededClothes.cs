using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class RemovingSomeOfSeededClothes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 15);

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
                keyValue: 2,
                columns: new[] { "Color", "ImageUrl", "Name", "Size" },
                values: new object[] { "White", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white-510x510.jpg", "Hardcore T-shirt White", "S" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name", "Size" },
                values: new object[] { "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range /o  motion to get you through your workout in total comfort.", "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg? width=800&height=800&hash=1600", "Gym Warrior T-shirt Black", "S" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "Description", "ImageUrl", "Name" },
                values: new object[] { "Black", "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range of motion  to get you through your workout in total comfort.", "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeat-t- shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit", "The Cicle T-shirt Black" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Color", "Description", "ImageUrl", "Name", "Price", "Size", "WearCategoryId" },
                values: new object[] { "Black", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "https://www.hard-wear.com/media/catalog/product/cache/b8bf61042c9b806ea0edf19101a0211e/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg", "Hardcore Hoodie Black", 49.99m, "S", 2 });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "Size", "WearCategoryId" },
                values: new object[] { "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-Hardcore-Sportswear-Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg", "Hardcore Hoodie White", 49.99m, "S", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "ImageUrl", "Name", "Size" },
                values: new object[] { "Black", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-black.jpg", "Hardcore T-shirt Black", "M" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name", "Size" },
                values: new object[] { "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-black.jpg", "Hardcore T-shirt Black", "L" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "Description", "ImageUrl", "Name" },
                values: new object[] { "White", "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white-510x510.jpg", "Hardcore T-shirt White" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Color", "Description", "ImageUrl", "Name", "Price", "Size", "WearCategoryId" },
                values: new object[] { "White", "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white-510x510.jpg", "Hardcore T-shirt White", 29.99m, "M", 1 });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "Size", "WearCategoryId" },
                values: new object[] { "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white-510x510.jpg", "Hardcore T-shirt White", 29.99m, "L", 1 });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "Color", "Description", "Fabric", "ImageUrl", "Name", "Price", "Size", "WearCategoryId" },
                values: new object[,]
                {
                    { 7, "Black", "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range /o  motion to get you through your workout in total comfort.", "Cutton", "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg? width=800&height=800&hash=1600", "Gym Warrior T-shirt Black", 29.99m, "S", 1 },
                    { 8, "Black", "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range /o  motion to get you through your workout in total comfort.", "Cutton", "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg? width=800&height=800&hash=1600", "Gym Warrior T-shirt Black", 29.99m, "M", 1 },
                    { 9, "Black", "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range /o  motion to get you through your workout in total comfort.", "Cutton", "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg? width=800&height=800&hash=1600", "Gym Warrior T-shirt Black", 29.99m, "L", 1 },
                    { 10, "Black", "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range of motion  to get you through your workout in total comfort.", "Cutton", "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeat-t- shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit", "The Cicle T-shirt Black", 29.99m, "S", 1 },
                    { 11, "Black", "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range of motion  to get you through your workout in total comfort.", "Cutton", "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeat-t- shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit", "The Cicle T-shirt Black", 29.99m, "M", 1 },
                    { 12, "Black", "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range of motion  to get you through your workout in total comfort.", "Cutton", "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeat-t- shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit", "The Cicle T-shirt Black", 29.99m, "L", 1 },
                    { 13, "Black", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "Cutton", "https://www.hard-wear.com/media/catalog/product/cache/b8bf61042c9b806ea0edf19101a0211e/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg", "Hardcore Hoodie Black", 49.99m, "S", 2 },
                    { 14, "Black", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "Cutton", "https://www.hard-wear.com/media/catalog/product/cache/b8bf61042c9b806ea0edf19101a0211e/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg", "Hardcore Hoodie Black", 49.99m, "M", 2 },
                    { 15, "Black", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "Cutton", "https://www.hard-wear.com/media/catalog/product/cache/b8bf61042c9b806ea0edf19101a0211e/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg", "Hardcore Hoodie Black", 49.99m, "L", 2 },
                    { 16, "White", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "Cutton", "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-Hardcore-Sportswear-Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg", "Hardcore Hoodie White", 49.99m, "S", 2 },
                    { 17, "White", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "Cutton", "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-Hardcore-Sportswear-Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg", "Hardcore Hoodie White", 49.99m, "M", 2 },
                    { 18, "White", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "Cutton", "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-Hardcore-Sportswear-Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg", "Hardcore Hoodie White", 49.99m, "L", 2 }
                });
        }
    }
}
