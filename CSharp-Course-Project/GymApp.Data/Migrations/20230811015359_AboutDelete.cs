using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class AboutDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "22c59ec0-4253-48ef-bcf7-355bbd743b40");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "a425d937-d407-461f-9218-31c6c0d7586b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "beaadb0c-616c-4e7d-ab40-e1a0b6e54065", new DateTime(2023, 8, 11, 1, 53, 58, 860, DateTimeKind.Utc).AddTicks(1491), "AQAAAAEAACcQAAAAEP+p/dpOJH05XkmpGwxFag35wMgMxG8ECURSLYqT98igV5YQfYNJkT/B3aR9RmrVXg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "fc16c0e9-f58f-40ba-8b38-9e59123e8f87", new DateTime(2023, 8, 11, 1, 53, 58, 857, DateTimeKind.Utc).AddTicks(7638), "AQAAAAEAACcQAAAAEMHcbXPeDDEktlJ+rwYrPc02BlUrzOJB1fs9/mKsN/ifPkFN9L04gOnP4cJ3j3c/Mg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "b2bff7b0-e85d-44a4-a370-79c11bb8c390", new DateTime(2023, 8, 11, 1, 53, 58, 858, DateTimeKind.Utc).AddTicks(9676), "AQAAAAEAACcQAAAAEH9qyd5Yr20RQA1Rbhpd3u011f6YSxVj+93JoBaho9EyII4alrRBjYdIpx5Z+W/ZZw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "2bc834d4-cc37-4829-95cb-130e2e5b1cf1", new DateTime(2023, 8, 11, 1, 53, 58, 856, DateTimeKind.Utc).AddTicks(5749), "AQAAAAEAACcQAAAAECA4iDn5ffXfKeBHawARnM1Uyxj31QEQpBn7cLkF7LotcKO7c6tc9D3bKzCEiWKkDw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "6d5a3883-1cf0-475a-983b-096606cb0cfc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "29804b3a-6473-411a-a23f-e0df454b3662");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "a7fcade5-cab9-4a97-818b-a647b1ff2553", new DateTime(2023, 8, 10, 19, 54, 29, 398, DateTimeKind.Utc).AddTicks(3761), "AQAAAAEAACcQAAAAELU5hUv8hnjF0LNO/2gY3RaMtlmVYHklDqZtRtS5r4Ig/s7zXSWuBEwgI5Oyba1nIg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "65e4d991-3fb4-49b0-8734-eb021bd63ff5", new DateTime(2023, 8, 10, 19, 54, 29, 395, DateTimeKind.Utc).AddTicks(8863), "AQAAAAEAACcQAAAAEN620u7S+xsbtkyY7D8gEcnpt6eI9QB+HqFqigPzbNhAjo/aBKQ0dr66GPBKrbmGsg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "5d793528-37d5-4e7d-9057-0ed8e200bf1e", new DateTime(2023, 8, 10, 19, 54, 29, 397, DateTimeKind.Utc).AddTicks(1484), "AQAAAAEAACcQAAAAEC1Hxo2eb/w5Euu3WfAmTnOnMGDJ/IWtcOrcgLyIQMIVwgKQheeGag1K7N9EQruCsw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "62f4222c-03f1-4203-b81e-05dc5f7573dd", new DateTime(2023, 8, 10, 19, 54, 29, 394, DateTimeKind.Utc).AddTicks(6966), "AQAAAAEAACcQAAAAECtOyDS3VH9TIdZXKcWEkaUmgIJk6KpO6MlxaUNquYumOIL/9Xnb2KOACpgx6Ga3Gg==" });
        }
    }
}
