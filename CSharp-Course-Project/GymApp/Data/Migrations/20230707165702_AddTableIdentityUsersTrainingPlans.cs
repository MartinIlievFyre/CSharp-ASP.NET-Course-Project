using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class AddTableIdentityUsersTrainingPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityUsersTrainingPlans",
                columns: table => new
                {
                    TrainingGuyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsersTrainingPlans", x => new { x.TrainingGuyId, x.TrainingPlanId });
                    table.ForeignKey(
                        name: "FK_IdentityUsersTrainingPlans_AspNetUsers_TrainingGuyId",
                        column: x => x.TrainingGuyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUsersTrainingPlans_TrainingPlans_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_CategoryId",
                table: "TrainingPlans",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUsersTrainingPlans_TrainingPlanId",
                table: "IdentityUsersTrainingPlans",
                column: "TrainingPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Categories_CategoryId",
                table: "TrainingPlans",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_Categories_CategoryId",
                table: "TrainingPlans");

            migrationBuilder.DropTable(
                name: "IdentityUsersTrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlans_CategoryId",
                table: "TrainingPlans");
        }
    }
}
