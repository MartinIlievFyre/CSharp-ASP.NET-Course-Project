using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class ChangePicturesOfSomeClothes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white.jpg");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://www.hard-wear.com/media/catalog/product/cache/74aab73cb060cf90b1e98012d0101b9a/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-/white-510x510.jpg");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://www.hard-wear.com/media/catalog/product/cacheb8bf61042c9b806ea0edf19101a0211e/1/0/100-//hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg");
        }
    }
}
