using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class AddingNormalizedEmailToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "a7fcade5-cab9-4a97-818b-a647b1ff2553", new DateTime(2023, 8, 10, 19, 54, 29, 398, DateTimeKind.Utc).AddTicks(3761), "ADMIN@ABV.COM", "AQAAAAEAACcQAAAAELU5hUv8hnjF0LNO/2gY3RaMtlmVYHklDqZtRtS5r4Ig/s7zXSWuBEwgI5Oyba1nIg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "65e4d991-3fb4-49b0-8734-eb021bd63ff5", new DateTime(2023, 8, 10, 19, 54, 29, 395, DateTimeKind.Utc).AddTicks(8863), "MONIKAO2@ABV.COM", "AQAAAAEAACcQAAAAEN620u7S+xsbtkyY7D8gEcnpt6eI9QB+HqFqigPzbNhAjo/aBKQ0dr66GPBKrbmGsg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "Email", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "5d793528-37d5-4e7d-9057-0ed8e200bf1e", new DateTime(2023, 8, 10, 19, 54, 29, 397, DateTimeKind.Utc).AddTicks(1484), "presko03@abv.com", "PRESKO03@ABV.COM", "AQAAAAEAACcQAAAAEC1Hxo2eb/w5Euu3WfAmTnOnMGDJ/IWtcOrcgLyIQMIVwgKQheeGag1K7N9EQruCsw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "62f4222c-03f1-4203-b81e-05dc5f7573dd", new DateTime(2023, 8, 10, 19, 54, 29, 394, DateTimeKind.Utc).AddTicks(6966), "VLADO01@ABV.COM", "AQAAAAEAACcQAAAAECtOyDS3VH9TIdZXKcWEkaUmgIJk6KpO6MlxaUNquYumOIL/9Xnb2KOACpgx6Ga3Gg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "e757b8e3-9c52-4650-b0af-9c2b65b67e02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "c10bf1ca-7130-45c4-bb69-336e404b17d6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ce360d2d-704f-4d87-9fa2-76b82dfa762f", new DateTime(2023, 8, 9, 22, 45, 53, 31, DateTimeKind.Utc).AddTicks(6077), null, "AQAAAAEAACcQAAAAEKXsLMIZHDryQH5M6uIX6wr1a06kB3oNnfe2lX3L/KGxp3ZaIu+O9D7ixgzDRjQPoA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "549bf90e-fa20-4c0f-89d6-7731b3910be8", new DateTime(2023, 8, 9, 22, 45, 53, 28, DateTimeKind.Utc).AddTicks(3541), null, "AQAAAAEAACcQAAAAEFmx1tvovOSQ8QysYvPGWn/QC8E/ALxFuJy9Dl0+GjbGhQJZaU6cxV0ERy56k5kXbQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "Email", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "4f7b1511-256f-454e-89dd-4ab91f37f0bb", new DateTime(2023, 8, 9, 22, 45, 53, 30, DateTimeKind.Utc).AddTicks(253), "presko-03@abv.com", null, "AQAAAAEAACcQAAAAEC0/DhELSk3QZ9Iy8k9su1uwuAvoFpuvqazUzzEzEN9a3FeP0cYwqmz0ikVPvjG3tw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "77824c96-2511-4d36-bf65-94fa0b7d2917", new DateTime(2023, 8, 9, 22, 45, 53, 26, DateTimeKind.Utc).AddTicks(7724), null, "AQAAAAEAACcQAAAAEKSYTeyytNYCrZBIU005a/DfqTjzU7bbpWEnoAyr8lQajgdblaSz20++Fgzq3bswnw==" });
        }
    }
}
