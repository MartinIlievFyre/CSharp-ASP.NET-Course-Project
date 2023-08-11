using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class EditImageOfAccessory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/1/_/1_2.png");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "7da25ad8-e36d-4479-b000-27e85e9813e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "ae4ac668-66d4-48b3-a58b-debc0f8e7591");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "d90f1cca-0dcb-483c-881b-d92d8111d6c4", new DateTime(2023, 8, 11, 21, 52, 37, 934, DateTimeKind.Utc).AddTicks(555), "AQAAAAEAACcQAAAAEOLQwARVNRw/Zs2cLchvxUAs/q37ER2yah1Z3tDcwWE34iJXaw2bDeehezp5RcWLlA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "103dc6b6-5a36-4a39-a6ed-8bd839ca7dad", new DateTime(2023, 8, 11, 21, 52, 37, 931, DateTimeKind.Utc).AddTicks(7025), "AQAAAAEAACcQAAAAEPQmOh2tKLK/ZWn38m5/+sXehB35FWwJqWd44eFbj7JagToqHzDZLH2tlzLpEsCMKw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "ef3a6787-6ae4-48f3-bb87-d1a5a1df6bb3", new DateTime(2023, 8, 11, 21, 52, 37, 932, DateTimeKind.Utc).AddTicks(8805), "AQAAAAEAACcQAAAAEDanhX8kFGtw07q6s1xdNBbtfH3AgFfvyndeWpS3/h3b3w5uy0ZKuB/ljGiVKNsSdg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "bd366743-daf9-4d6b-8832-09282f28816c", new DateTime(2023, 8, 11, 21, 52, 37, 930, DateTimeKind.Utc).AddTicks(5081), "AQAAAAEAACcQAAAAEKQTjuaxI9h6Mbxi6G+zWFU56bFogPDLDJmltLmmwdadfyg2aMOsiLT1b0EsLbHfvQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/h/a/hand-grip_trainer_gymbeam1.jpg");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "ec7b7e64-fcb4-475a-b04f-96feca2c4047");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "c3a1d5cb-0e86-40ab-88d2-6f5ed633c661");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "7c09c4a7-32ed-44b7-b2de-47c037b3776b", new DateTime(2023, 8, 11, 21, 49, 34, 914, DateTimeKind.Utc).AddTicks(7146), "AQAAAAEAACcQAAAAEKYZs+jEFVAYobzrkNXLZhQ/a3ZNW/7X/Wz1bvhzqvPaBnlNFiNvWQ/ssryRQkLhTw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "cc095c1e-e043-41ed-b867-c130d689405d", new DateTime(2023, 8, 11, 21, 49, 34, 912, DateTimeKind.Utc).AddTicks(4182), "AQAAAAEAACcQAAAAEC7DDHYMpqBFgcGxC2+X2COlmlAiHJCYylYjFcwBc/uh1E/p411hrAfiZDwdV0H7eQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "54632d26-2752-4394-9f52-021329f0e507", new DateTime(2023, 8, 11, 21, 49, 34, 913, DateTimeKind.Utc).AddTicks(5655), "AQAAAAEAACcQAAAAEPNftemYF9/rZa6sn+g99ZZwwVPC4KaDsn62iYxR1c9vrNGdiSA48DDbKd9uE9HgWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "91737648-0364-4c07-a553-fcfdecb8ce44", new DateTime(2023, 8, 11, 21, 49, 34, 911, DateTimeKind.Utc).AddTicks(2404), "AQAAAAEAACcQAAAAEFXQuqetOd/ELR09NV8NaCoXS+fVM5lrEFtP/yNAbDuOXndyiyzaKdoctap5c70u0Q==" });
        }
    }
}
