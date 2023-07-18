using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class RenameFoodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersFoods_Foods_FoodId",
                table: "ApplicationUsersFoods");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.CreateTable(
                name: "UsersFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Carbs = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Fat = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Protein = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Grams = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFoods", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UsersFoods",
                columns: new[] { "Id", "Calories", "Carbs", "Fat", "Grams", "Name", "Protein" },
                values: new object[] { 1, 52, 13.800000000000001, 0.20000000000000001, 0, "Apple", 0.29999999999999999 });

            migrationBuilder.InsertData(
                table: "UsersFoods",
                columns: new[] { "Id", "Calories", "Fat", "Grams", "Name", "Protein" },
                values: new object[] { 2, 153, 3.6000000000000001, 0, "Chicken Fillet", 30.199999999999999 });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersFoods_UsersFoods_FoodId",
                table: "ApplicationUsersFoods",
                column: "FoodId",
                principalTable: "UsersFoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersFoods_UsersFoods_FoodId",
                table: "ApplicationUsersFoods");

            migrationBuilder.DropTable(
                name: "UsersFoods");

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calories = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Carbs = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Fat = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Grams = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Calories", "Carbs", "Fat", "Grams", "Name", "Protein" },
                values: new object[] { 1, 52, 13.800000000000001, 0.20000000000000001, 0, "Apple", 0.29999999999999999 });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Calories", "Carbs", "Fat", "Grams", "Name", "Protein" },
                values: new object[] { 2, 153, 0.0, 3.6000000000000001, 0, "Chicken Fillet", 30.199999999999999 });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersFoods_Foods_FoodId",
                table: "ApplicationUsersFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
