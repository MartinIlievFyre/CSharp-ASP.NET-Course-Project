using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class UpdateNormalizedEmailOfMonikaUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "e3fd6019-193e-4af3-bcfa-acbf85f1c9d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "1eaaad87-67cc-499f-a84c-38278d84793d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "53fa3cc4-91ae-4686-832d-e69a70e437b5", new DateTime(2023, 8, 11, 13, 14, 31, 781, DateTimeKind.Utc).AddTicks(1403), "AQAAAAEAACcQAAAAEJtd8eh37GfS0BS+mdWVEjpVcY2xrq+tUGqC1+vGgMrOteJGN0bMzcaR5FAYLDnB6Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "92a98427-eaf9-4818-9220-e9e2c7e089b8", new DateTime(2023, 8, 11, 13, 14, 31, 778, DateTimeKind.Utc).AddTicks(6851), "MONIKA02@ABV.COM", "AQAAAAEAACcQAAAAEACtYHt107zsqUBGQV8yJ+T7ftPIZA6yYlOTpE7BZlVdy/2JHURzqXc6AxLEJGYTRQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "175c4739-aaa9-4ab9-8690-3e0afb4aec54", new DateTime(2023, 8, 11, 13, 14, 31, 779, DateTimeKind.Utc).AddTicks(8747), "AQAAAAEAACcQAAAAEDGIAsCBDE/MA+bIyPZuFB8EyXkUboA/lmGcAmHHGUgmOr5Zuc1CatK5cWCJwyHQDg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "1758e956-e02d-490a-89bd-4e10dcc0d01d", new DateTime(2023, 8, 11, 13, 14, 31, 777, DateTimeKind.Utc).AddTicks(4656), "AQAAAAEAACcQAAAAEI7+WEHV8uy3VhSCmxTHuP0cS47voGDv3SIaomVRv/H1RPwnlnmw7B+G+4mvQmHCtg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "fc16c0e9-f58f-40ba-8b38-9e59123e8f87", new DateTime(2023, 8, 11, 1, 53, 58, 857, DateTimeKind.Utc).AddTicks(7638), "MONIKAO2@ABV.COM", "AQAAAAEAACcQAAAAEMHcbXPeDDEktlJ+rwYrPc02BlUrzOJB1fs9/mKsN/ifPkFN9L04gOnP4cJ3j3c/Mg==" });

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
    }
}
