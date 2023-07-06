using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class AddTableTrainingPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingPlanId",
                table: "IdentityUsersExercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrainingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUsersExercises_TrainingPlanId",
                table: "IdentityUsersExercises",
                column: "TrainingPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsersExercises_TrainingPlans_TrainingPlanId",
                table: "IdentityUsersExercises",
                column: "TrainingPlanId",
                principalTable: "TrainingPlans",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersExercises_TrainingPlans_TrainingPlanId",
                table: "IdentityUsersExercises");

            migrationBuilder.DropTable(
                name: "TrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_IdentityUsersExercises_TrainingPlanId",
                table: "IdentityUsersExercises");

            migrationBuilder.DropColumn(
                name: "TrainingPlanId",
                table: "IdentityUsersExercises");
        }
    }
}
