using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class AddFabricPropertyToWearEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fabric",
                table: "Clothes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fabric", "ImageUrl" },
                values: new object[] { "Cutton", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-black.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Fabric", "ImageUrl" },
                values: new object[] { "Cutton", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-black.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Fabric", "ImageUrl" },
                values: new object[] { "Cutton", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-black.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Fabric", "ImageUrl" },
                values: new object[] { "Cutton", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white-510x510.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Fabric", "ImageUrl" },
                values: new object[] { "Cutton", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white-510x510.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Fabric", "ImageUrl" },
                values: new object[] { "Cutton", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white-510x510.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fabric",
                value: "Cutton");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fabric",
                value: "Cutton");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fabric",
                value: "Cutton");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fabric",
                value: "Cutton");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fabric",
                value: "Cutton");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fabric",
                value: "Cutton");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fabric",
                value: "Cutton");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fabric",
                value: "Cutton");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fabric",
                value: "Cutton");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fabric",
                table: "Clothes");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://100procenthardcore.ams3.digitaloceanspaces.com/wp-content/ uploads/2023/2023/05/29213518/305-B01-050-voor.jpeg");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://100procenthardcore.ams3.digitaloceanspaces.com/wp-content/ uploads/2023/2023/05/29213518/305-B01-050-voor.jpeg");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://100procenthardcore.ams3.digitaloceanspaces.com/wp-content/ uploads/2023/2023/05/29213518/305-B01-050-voor.jpeg");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://100procenthardcore.com/wp-content/uploads/2023/05/305-B01-100-100-Hardcore-T-Shirt-Wear- It-With-Pride-Wit-1.jpg");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://100procenthardcore.com/wp-content/uploads/2023/05/305-B01-100-100-Hardcore-T-Shirt-Wear- It-With-Pride-Wit-1.jpg");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://100procenthardcore.com/wp-content/uploads/2023/05/305-B01-100-100-Hardcore-T-Shirt-Wear- It-With-Pride-Wit-1.jpg");
        }
    }
}
