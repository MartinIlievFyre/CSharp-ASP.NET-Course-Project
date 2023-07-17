using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class AddColumnGramsInFoodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Grams",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://adventurefitness.club/wp-content/uploads/2022/11/lying-triceps-extension-vs-skullcrusher.jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grams",
                table: "Foods");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://www.fitliferegime.com/wp-content/uploads/2022/03/Barbell-Skull-Crushers.jpg?ezimgfmt=rs:382x215/rscb1/ngcb1/notWebP");
        }
    }
}
