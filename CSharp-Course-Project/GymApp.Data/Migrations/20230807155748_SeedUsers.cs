using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "e5bf4d37-a27b-40c8-b944-ddb26c92b6ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "5459b93f-4ebc-454d-a4ce-9fbb29029249");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "IsDeleted", "IsModerator", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"), 0, "c93d9503-8146-4e7b-98c5-5e4ea2bebe8f", new DateTime(2023, 8, 7, 15, 57, 47, 940, DateTimeKind.Utc).AddTicks(9273), "admin@abv.com", false, false, false, false, null, null, null, "admin", "AQAAAAEAACcQAAAAEDvBNOyUiJol951mXSREdmW9o0CP3kRq6BwPYX4e3TqLUXdmyObQJK90QSbY5D6eaw==", null, false, null, "SecurityStamp01", false, "admin" },
                    { new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"), 0, "db267b41-6178-4157-8950-302ba549c6f8", new DateTime(2023, 8, 7, 15, 57, 47, 938, DateTimeKind.Utc).AddTicks(5582), "monika02@abv.com", false, false, false, false, null, null, null, "MONIKA-02", "AQAAAAEAACcQAAAAEP0UpvBcSB9bexAu5uTnH8sVOp/YYpOqyCOPKtTDVmIoazmVUQ3PKNfjk9p3xZLrYA==", null, false, null, "SecurityStamp01", false, "Monika-02" },
                    { new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"), 0, "2c3e71f0-dac2-481f-8ef8-cf43cc2fd3ba", new DateTime(2023, 8, 7, 15, 57, 47, 939, DateTimeKind.Utc).AddTicks(7492), "presko-03@abv.com", false, false, false, false, null, null, null, "PRESLAV-03", "AQAAAAEAACcQAAAAEJsW8io+Aug86SZBuJnZYjnhj+pkQc/eKU9UmH6EVWj+j9nDR6EaeYNUBiT3iALcPw==", null, false, null, "SecurityStamp01", false, "Preslav-03" },
                    { new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"), 0, "297d8dc7-0c2a-47c9-befd-b187b7322448", new DateTime(2023, 8, 7, 15, 57, 47, 937, DateTimeKind.Utc).AddTicks(3686), "vlado01@abv.com", false, false, false, false, null, null, null, "VLADO-01", "AQAAAAEAACcQAAAAEN372X6Yp1YY4y4+TqaRy8acjgWHNKX3nfGUFB5iUm8ALLeFALv5uFne6PQWisPjJw==", null, false, null, "SecurityStamp01", false, "Vlado-01" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"), new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2") },
                    { new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"), new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff") },
                    { new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"), new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554") },
                    { new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"), new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"), new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"), new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"), new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"), new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "d099828b-4007-464d-bba1-d04d609f4315");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "cbbf56a9-28e0-4063-a7da-556e590b4837");
        }
    }
}
