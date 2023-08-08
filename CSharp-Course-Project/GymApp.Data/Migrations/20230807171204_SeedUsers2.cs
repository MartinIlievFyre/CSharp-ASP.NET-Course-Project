using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class SeedUsers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "b662c9f2-284e-4fea-8627-7f0966c1d834", new DateTime(2023, 8, 7, 17, 12, 3, 783, DateTimeKind.Utc).AddTicks(9130), "AQAAAAEAACcQAAAAEAkqABWIfrGI7SFHejjYPMPn7S6t46EtAZcHcmXBo3zXZqgANDe+xNef9huJ8H9Oqg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "b3288a2b-da97-4f21-9552-861a1335aed4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "0d4a6abc-1daf-48e1-aca5-e274a9853670");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "986311db-8935-43ed-a06d-ec51955fdaa9", new DateTime(2023, 8, 7, 16, 39, 37, 152, DateTimeKind.Utc).AddTicks(2306), "AQAAAAEAACcQAAAAEL/D5LtIHyd94PtkB0A5NXfN82BZ9oxuVRCNRwOHVCHZAOpGkVS/z19mGT4mxN7vhw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "c6f40ac9-9c01-443f-8853-64d550fa857a", new DateTime(2023, 8, 7, 16, 39, 37, 149, DateTimeKind.Utc).AddTicks(7012), "AQAAAAEAACcQAAAAEEa2NjOQstS+KBmG2v19vTcQntr0LWwEdxiBmlXm6GnngkASmJBNUSKv+0oiMWAdBA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "df00bc2e-61c9-4951-b38f-6ed7dfb00f19", new DateTime(2023, 8, 7, 16, 39, 37, 150, DateTimeKind.Utc).AddTicks(8882), "AQAAAAEAACcQAAAAEBiOpjn0GfCfwHOaexT88jOjzVUI4s7yfTaac3x6qEY9qEcUQqCmSQL+Y0dVjGV/ZQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "fa5e42d0-4a4f-413f-923f-dffcc774f7bc", new DateTime(2023, 8, 7, 16, 39, 37, 148, DateTimeKind.Utc).AddTicks(5044), "AQAAAAEAACcQAAAAEDvG3HbcSZS6r3QenSEToW6dQPCOJ9lF7RWzGwjVCMMPN/GS2zKPrS1jA50MhUXF7g==" });
        }
    }
}
