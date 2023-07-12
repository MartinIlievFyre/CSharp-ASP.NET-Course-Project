using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class AddIdentityUsersTrainingPlansTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserTrainingPlan_AspNetUsers_TrainingGuyId",
                table: "IdentityUserTrainingPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserTrainingPlan_TrainingPlans_TrainingPlanId",
                table: "IdentityUserTrainingPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserTrainingPlan",
                table: "IdentityUserTrainingPlan");

            migrationBuilder.RenameTable(
                name: "IdentityUserTrainingPlan",
                newName: "IdentityUsersTrainingPlans");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserTrainingPlan_TrainingPlanId",
                table: "IdentityUsersTrainingPlans",
                newName: "IX_IdentityUsersTrainingPlans_TrainingPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUsersTrainingPlans",
                table: "IdentityUsersTrainingPlans",
                columns: new[] { "TrainingGuyId", "TrainingPlanId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsersTrainingPlans_AspNetUsers_TrainingGuyId",
                table: "IdentityUsersTrainingPlans",
                column: "TrainingGuyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsersTrainingPlans_TrainingPlans_TrainingPlanId",
                table: "IdentityUsersTrainingPlans",
                column: "TrainingPlanId",
                principalTable: "TrainingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersTrainingPlans_AspNetUsers_TrainingGuyId",
                table: "IdentityUsersTrainingPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersTrainingPlans_TrainingPlans_TrainingPlanId",
                table: "IdentityUsersTrainingPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUsersTrainingPlans",
                table: "IdentityUsersTrainingPlans");

            migrationBuilder.RenameTable(
                name: "IdentityUsersTrainingPlans",
                newName: "IdentityUserTrainingPlan");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUsersTrainingPlans_TrainingPlanId",
                table: "IdentityUserTrainingPlan",
                newName: "IX_IdentityUserTrainingPlan_TrainingPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserTrainingPlan",
                table: "IdentityUserTrainingPlan",
                columns: new[] { "TrainingGuyId", "TrainingPlanId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserTrainingPlan_AspNetUsers_TrainingGuyId",
                table: "IdentityUserTrainingPlan",
                column: "TrainingGuyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserTrainingPlan_TrainingPlans_TrainingPlanId",
                table: "IdentityUserTrainingPlan",
                column: "TrainingPlanId",
                principalTable: "TrainingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
