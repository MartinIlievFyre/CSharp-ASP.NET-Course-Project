using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class AddSecurityStampOnFirstSeededUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "95f7daef-16c2-4594-92bf-bbd674c6a8b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "f36702ab-7c14-4051-bc7f-2e776fb7eb34");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "c687ec6e-804c-4199-8aea-d3cac678b2d7", new DateTime(2023, 8, 8, 17, 41, 29, 303, DateTimeKind.Utc).AddTicks(7421), "AQAAAAEAACcQAAAAEHDxHB2nVlQXUTEmN2CEaVy6r+bSXKKkKXi3sUOlBv/1+R2W7V20gSE1MlmeYPfw5A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "6a408014-3fde-4727-b361-a7689ec946d2", new DateTime(2023, 8, 8, 17, 41, 29, 301, DateTimeKind.Utc).AddTicks(4005), "AQAAAAEAACcQAAAAEH2s46W2pK++ZaYhUalI6t+fbQyJoaET6Lj691m1KQ9ke3uQ7RtzlljqHsUJmEOa4Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "73af3145-c508-47b8-b14e-fc1361938702", new DateTime(2023, 8, 8, 17, 41, 29, 302, DateTimeKind.Utc).AddTicks(5655), "AQAAAAEAACcQAAAAEFea3fac/lMeaGLxaeDfM4/zokuqseZbOPminyGhjQbmf+GLviVaIWnfPRqV7HGtIQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "756b732a-37de-49a7-bca1-7b03316d4d46", new DateTime(2023, 8, 8, 17, 41, 29, 300, DateTimeKind.Utc).AddTicks(2042), "AQAAAAEAACcQAAAAEH3sy/URFR0g8xg0bgkVOwdfZvPVTI744gBMvyPRl1ES1caaNJy50pKNdvtwOlGxlA==", "SecurityStamp01" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "a2457c19-dfa3-4ff5-82a0-7fec62369041");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "0022f7a8-59ae-49f0-acf5-d8cbf5236980");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "9041a281-a2fe-423f-a58f-92ef44ff4c02", new DateTime(2023, 8, 8, 17, 40, 0, 636, DateTimeKind.Utc).AddTicks(8177), "AQAAAAEAACcQAAAAELp8LG7PS4HEHm6ius9hvUCuK28CvmvtBuUSue+sLn4QZAqP+p14qbjuMqj8A3HMEw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "426bb86c-17cc-458f-aba4-763d48ac7c02", new DateTime(2023, 8, 8, 17, 40, 0, 633, DateTimeKind.Utc).AddTicks(6859), "AQAAAAEAACcQAAAAEEVkxyh2WLBzHlj039oGarAm57Snkd7w7CI76P3+UNGAulxGQwxDQxnllCFNVIeudA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "8ae8fc90-df12-489f-8187-dd56f4e51df2", new DateTime(2023, 8, 8, 17, 40, 0, 635, DateTimeKind.Utc).AddTicks(2683), "AQAAAAEAACcQAAAAEGhWtfyal6ZYQA9sDGcbOBarjpxmydEtxB5ESS5XEUUfiSFzmc4EKCHSK32gRif/vQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82aaba8e-1fc9-4199-a327-5029abce71b2", new DateTime(2023, 8, 8, 17, 40, 0, 632, DateTimeKind.Utc).AddTicks(1312), "AQAAAAEAACcQAAAAEAlBVHtSkSUYDiWnuz59h9bQ9vo3CnL61Dy8RRMCVGRwmUCznzSiuqsmF4pnGDRmuQ==", null });
        }
    }
}
