using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class AddTablesFoodAndIdentityUserFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserFood_AspNetUsers_TrainingGuyId",
                table: "IdentityUserFood");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserFood_Food_FoodId",
                table: "IdentityUserFood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserFood",
                table: "IdentityUserFood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.RenameTable(
                name: "IdentityUserFood",
                newName: "IdentityUsersFoods");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Foods");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserFood_FoodId",
                table: "IdentityUsersFoods",
                newName: "IX_IdentityUsersFoods_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUsersFoods",
                table: "IdentityUsersFoods",
                columns: new[] { "TrainingGuyId", "FoodId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsersFoods_AspNetUsers_TrainingGuyId",
                table: "IdentityUsersFoods",
                column: "TrainingGuyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsersFoods_Foods_FoodId",
                table: "IdentityUsersFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersFoods_AspNetUsers_TrainingGuyId",
                table: "IdentityUsersFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersFoods_Foods_FoodId",
                table: "IdentityUsersFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUsersFoods",
                table: "IdentityUsersFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.RenameTable(
                name: "IdentityUsersFoods",
                newName: "IdentityUserFood");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUsersFoods_FoodId",
                table: "IdentityUserFood",
                newName: "IX_IdentityUserFood_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserFood",
                table: "IdentityUserFood",
                columns: new[] { "TrainingGuyId", "FoodId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserFood_AspNetUsers_TrainingGuyId",
                table: "IdentityUserFood",
                column: "TrainingGuyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserFood_Food_FoodId",
                table: "IdentityUserFood",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
