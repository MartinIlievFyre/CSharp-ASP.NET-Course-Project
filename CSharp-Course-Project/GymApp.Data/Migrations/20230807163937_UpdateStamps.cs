using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class UpdateStamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "986311db-8935-43ed-a06d-ec51955fdaa9", new DateTime(2023, 8, 7, 16, 39, 37, 152, DateTimeKind.Utc).AddTicks(2306), "AQAAAAEAACcQAAAAEL/D5LtIHyd94PtkB0A5NXfN82BZ9oxuVRCNRwOHVCHZAOpGkVS/z19mGT4mxN7vhw==", "SecurityStamp04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6f40ac9-9c01-443f-8853-64d550fa857a", new DateTime(2023, 8, 7, 16, 39, 37, 149, DateTimeKind.Utc).AddTicks(7012), "AQAAAAEAACcQAAAAEEa2NjOQstS+KBmG2v19vTcQntr0LWwEdxiBmlXm6GnngkASmJBNUSKv+0oiMWAdBA==", "SecurityStamp02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df00bc2e-61c9-4951-b38f-6ed7dfb00f19", new DateTime(2023, 8, 7, 16, 39, 37, 150, DateTimeKind.Utc).AddTicks(8882), "AQAAAAEAACcQAAAAEBiOpjn0GfCfwHOaexT88jOjzVUI4s7yfTaac3x6qEY9qEcUQqCmSQL+Y0dVjGV/ZQ==", "SecurityStamp03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "fa5e42d0-4a4f-413f-923f-dffcc774f7bc", new DateTime(2023, 8, 7, 16, 39, 37, 148, DateTimeKind.Utc).AddTicks(5044), "AQAAAAEAACcQAAAAEDvG3HbcSZS6r3QenSEToW6dQPCOJ9lF7RWzGwjVCMMPN/GS2zKPrS1jA50MhUXF7g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c93d9503-8146-4e7b-98c5-5e4ea2bebe8f", new DateTime(2023, 8, 7, 15, 57, 47, 940, DateTimeKind.Utc).AddTicks(9273), "AQAAAAEAACcQAAAAEDvBNOyUiJol951mXSREdmW9o0CP3kRq6BwPYX4e3TqLUXdmyObQJK90QSbY5D6eaw==", "SecurityStamp01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db267b41-6178-4157-8950-302ba549c6f8", new DateTime(2023, 8, 7, 15, 57, 47, 938, DateTimeKind.Utc).AddTicks(5582), "AQAAAAEAACcQAAAAEP0UpvBcSB9bexAu5uTnH8sVOp/YYpOqyCOPKtTDVmIoazmVUQ3PKNfjk9p3xZLrYA==", "SecurityStamp01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c3e71f0-dac2-481f-8ef8-cf43cc2fd3ba", new DateTime(2023, 8, 7, 15, 57, 47, 939, DateTimeKind.Utc).AddTicks(7492), "AQAAAAEAACcQAAAAEJsW8io+Aug86SZBuJnZYjnhj+pkQc/eKU9UmH6EVWj+j9nDR6EaeYNUBiT3iALcPw==", "SecurityStamp01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "297d8dc7-0c2a-47c9-befd-b187b7322448", new DateTime(2023, 8, 7, 15, 57, 47, 937, DateTimeKind.Utc).AddTicks(3686), "AQAAAAEAACcQAAAAEN372X6Yp1YY4y4+TqaRy8acjgWHNKX3nfGUFB5iUm8ALLeFALv5uFne6PQWisPjJw==" });
        }
    }
}
