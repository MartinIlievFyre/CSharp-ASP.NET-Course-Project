using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class AddTablesIdentityUserTrainingPlanAndIdentityUserFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersExercises_TrainingPlans_TrainingPlanId",
                table: "IdentityUsersExercises");

            migrationBuilder.DropIndex(
                name: "IX_IdentityUsersExercises_TrainingPlanId",
                table: "IdentityUsersExercises");

            migrationBuilder.DropColumn(
                name: "TrainingPlanId",
                table: "IdentityUsersExercises");

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Carbs = table.Column<int>(type: "int", nullable: false),
                    Fat = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserTrainingPlan",
                columns: table => new
                {
                    TrainingGuyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserTrainingPlan", x => new { x.TrainingGuyId, x.TrainingPlanId });
                    table.ForeignKey(
                        name: "FK_IdentityUserTrainingPlan_AspNetUsers_TrainingGuyId",
                        column: x => x.TrainingGuyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserTrainingPlan_TrainingPlans_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserFood",
                columns: table => new
                {
                    TrainingGuyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserFood", x => new { x.TrainingGuyId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_IdentityUserFood_AspNetUsers_TrainingGuyId",
                        column: x => x.TrainingGuyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserFood_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserFood_FoodId",
                table: "IdentityUserFood",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserTrainingPlan_TrainingPlanId",
                table: "IdentityUserTrainingPlan",
                column: "TrainingPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserFood");

            migrationBuilder.DropTable(
                name: "IdentityUserTrainingPlan");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.AddColumn<int>(
                name: "TrainingPlanId",
                table: "IdentityUsersExercises",
                type: "int",
                nullable: true);

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
    }
}
