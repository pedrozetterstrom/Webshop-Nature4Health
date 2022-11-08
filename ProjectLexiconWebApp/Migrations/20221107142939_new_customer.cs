using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLexiconWebApp.Migrations
{
    public partial class new_customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f74446a2-8eee-4e9d-a8ab-289b4115b8c4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e9e7b706-cf48-4da3-8753-d8e2b3b7fcab", "aa74b427-899a-41b2-bdfc-fd35557da933" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9e7b706-cf48-4da3-8753-d8e2b3b7fcab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa74b427-899a-41b2-bdfc-fd35557da933");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "433e77f7-a4b4-4a1f-a5ac-3a24f252bb8e", "3bfc981e-fc63-478a-aa75-96b6729059a8", "User", "USER" },
                    { "9cf7bc96-eff0-4e0a-8414-6fab94b54889", "5edf1bf5-5118-416f-a13d-a7262fb41f6a", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "dc6509b5-638e-431f-a8b9-8b63f01ac148", 0, "Adminsgatan 1", "Borås", "bf0486ad-67b6-45df-a0ce-d234b455690e", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEB3ql3ND9VE5yger9wyDCNL9Z9jn7hjOlNjvX3h/UKSrgJJit1PiQLsGp9TyPwLbgg==", "10101010101", null, false, "57acaa4d-b39f-496d-9dfd-ee0bbac17be7", false, "admin@n4h.com", "10001" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "CreatedAt", "EMail", "FirstName", "LastName", "Phone", "UserId", "Wallet", "ZipCode" },
                values: new object[] { 2, "Kundsgatan 1", "Göteborg", new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "user@n4h.com", "Customer Test", "Karlsson", "46780964", null, 1000.0m, "10001" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9cf7bc96-eff0-4e0a-8414-6fab94b54889", "dc6509b5-638e-431f-a8b9-8b63f01ac148" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipperId", "Status" },
                values: new object[] { 2, 2, new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), null, "pending" });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 5, 2, 1, 2 },
                    { 6, 2, 2, 2 },
                    { 7, 2, 3, 3 },
                    { 8, 2, 4, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "433e77f7-a4b4-4a1f-a5ac-3a24f252bb8e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9cf7bc96-eff0-4e0a-8414-6fab94b54889", "dc6509b5-638e-431f-a8b9-8b63f01ac148" });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cf7bc96-eff0-4e0a-8414-6fab94b54889");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc6509b5-638e-431f-a8b9-8b63f01ac148");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9e7b706-cf48-4da3-8753-d8e2b3b7fcab", "823bfd83-a150-47ef-a94f-d0defa7e6984", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f74446a2-8eee-4e9d-a8ab-289b4115b8c4", "f77d7a5c-864e-4b08-9461-4cc552e800a7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "aa74b427-899a-41b2-bdfc-fd35557da933", 0, "Adminsgatan 1", "Borås", "177d5fc9-0f8e-41b5-beb2-88cdc275dab1", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAECbOnwGX2jz3nudUh7bA5XmzG9PAtaRlWi5pDi1VoCyyIDQAdIPW/5ZrOxILIuMgKQ==", "10101010101", null, false, "532d35d8-6669-40e1-944b-9b92dc69e177", false, "admin@n4h.com", "10001" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e9e7b706-cf48-4da3-8753-d8e2b3b7fcab", "aa74b427-899a-41b2-bdfc-fd35557da933" });
        }
    }
}
