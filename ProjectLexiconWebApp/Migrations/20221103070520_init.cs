using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLexiconWebApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8ac3ffc-b8ec-4731-aa95-230f2a0c4cc6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0b970d62-6701-4de2-bddb-3a657beed82b", "dd745e28-585a-4222-b50c-f85d4fc7e54b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b970d62-6701-4de2-bddb-3a657beed82b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dd745e28-585a-4222-b50c-f85d4fc7e54b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ee205d3-be7c-4e14-b56c-6628a5c9f85f", "1e2acffe-36d5-43ed-bd81-a5bac461dda0", "Admin", "ADMIN" },
                    { "ab3c0b5f-2e06-4ce6-bf85-527da5d5f563", "ddf4a4bb-3826-441f-9e3f-0ba9a8ffdfd5", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "4fb5001d-fd58-44af-bc58-ee135968be61", 0, "Adminsgatan 1", "Borås", "1050710b-31e8-42c9-82e8-e47cc5de8281", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEHAZWw6n+KqwIK7VM6iAlJ4/UI0hoCh/QwpeNItItRfrvPJ/5/HnV2crhVkXvLC4cQ==", "10101010101", null, false, "a4f40b22-df97-4df4-b959-902fc0e1c9cf", false, "admin@n4h.com", "10001" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Picture",
                value: "../wwwroot/12345.png");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2ee205d3-be7c-4e14-b56c-6628a5c9f85f", "4fb5001d-fd58-44af-bc58-ee135968be61" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab3c0b5f-2e06-4ce6-bf85-527da5d5f563");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2ee205d3-be7c-4e14-b56c-6628a5c9f85f", "4fb5001d-fd58-44af-bc58-ee135968be61" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ee205d3-be7c-4e14-b56c-6628a5c9f85f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fb5001d-fd58-44af-bc58-ee135968be61");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b970d62-6701-4de2-bddb-3a657beed82b", "4e62a554-11e9-46d0-bb00-60ae73ce7d02", "Admin", "ADMIN" },
                    { "e8ac3ffc-b8ec-4731-aa95-230f2a0c4cc6", "41991a94-899a-4163-b310-7b4090890beb", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "dd745e28-585a-4222-b50c-f85d4fc7e54b", 0, "Adminsgatan 1", "Borås", "9aafb88b-f7f1-47c0-a5e4-3a36e0bfba2e", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEBMj+4KPoJZSExyrDIAdgCgYdol+4t6lyvP4cq830i6MZu+m7BYMFEfha32EyKRRGg==", "10101010101", null, false, "eb2b2bae-75b7-4174-ae14-01a067dc3b52", false, "admin@n4h.com", "10001" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Picture",
                value: null);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0b970d62-6701-4de2-bddb-3a657beed82b", "dd745e28-585a-4222-b50c-f85d4fc7e54b" });
        }
    }
}
