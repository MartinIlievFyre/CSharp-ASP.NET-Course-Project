using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class RemovedSecurityStampOnFirstSeededUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "87876019-338b-42a4-9010-5edb7b5d6e77");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "66075c3d-56ad-4793-9e30-09803c8ceb98");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "a3d9d134-3d47-4ad3-b4a0-a294a71e31b2", new DateTime(2023, 8, 7, 17, 12, 3, 787, DateTimeKind.Utc).AddTicks(3805), "AQAAAAEAACcQAAAAED/gs/A3g5VQGWVuLOsYFOZz3jPptMhpXN0pO2oz/+X9qJ1GA5MzdHx5m/GnxyDM0w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "ea98796e-5a82-4134-a693-315f6a658cd6", new DateTime(2023, 8, 7, 17, 12, 3, 785, DateTimeKind.Utc).AddTicks(947), "AQAAAAEAACcQAAAAEOgW6tAgPF3T6DMDkJQyiMiS1QXZw1QnhkCqEOuH4VNot27uQd6Thr/lVj8JXloP1Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "49c95df3-0515-4a47-b540-c2c4a8330df7", new DateTime(2023, 8, 7, 17, 12, 3, 786, DateTimeKind.Utc).AddTicks(2525), "AQAAAAEAACcQAAAAEANyf1zJlHpBVHNdb5VqSEMZnN0SumDsWr/GU8qhOrE1944fbCL5c9y58ltYhiUAWg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b662c9f2-284e-4fea-8627-7f0966c1d834", new DateTime(2023, 8, 7, 17, 12, 3, 783, DateTimeKind.Utc).AddTicks(9130), "AQAAAAEAACcQAAAAEAkqABWIfrGI7SFHejjYPMPn7S6t46EtAZcHcmXBo3zXZqgANDe+xNef9huJ8H9Oqg==", "SecurityStamp01" });
        }
    }
}
