using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class ChangedImageForSkullcrusherExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://cdn-0.weighttraining.guide/wp-content/uploads/2018/06/decline-ez-bar-skull-crusher-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://adventurefitness.club/wp-content/uploads/2022/11/lying-triceps-extension-vs-skullcrusher.jpeg");
        }
    }
}
