using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLexiconWebApp.Migrations
{
    public partial class change_roleId_tostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0fa68fd-23c8-42f9-b0a8-1fad8113b00e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "49c13023-a56d-40bd-a240-3b5b83a6b260", "4835f283-bc9b-4fe1-bb11-2c38ff7bfe6a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49c13023-a56d-40bd-a240-3b5b83a6b260");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4835f283-bc9b-4fe1-bb11-2c38ff7bfe6a");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02b9ab74-299c-4985-9e78-10eb0f943008", "bfcb9097-57ca-49f3-8dca-3710a49eb2c6", "User", "USER" },
                    { "dd28889b-3e16-444d-9e4b-9be3dc345298", "6dadb8c2-e904-4de5-806b-5c73968242bb", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "9822b3f1-7b56-4dac-baa9-6c1fdf77d11c", 0, "Adminsgatan 1", "Borås", "2ad11c0f-ac4d-4f18-a8fe-4883d6e4c569", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEGk9RwRPNebOKUaP1VYCsdDls+Jm0r0cS1WonUAKkuFEzOa8Ftacksrj7POlmbNb/w==", "10101010101", null, false, "54d6d7da-e0ac-4749-9077-7082eb24fe6b", false, "admin@n4h.com", "10001" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dd28889b-3e16-444d-9e4b-9be3dc345298", "9822b3f1-7b56-4dac-baa9-6c1fdf77d11c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02b9ab74-299c-4985-9e78-10eb0f943008");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dd28889b-3e16-444d-9e4b-9be3dc345298", "9822b3f1-7b56-4dac-baa9-6c1fdf77d11c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd28889b-3e16-444d-9e4b-9be3dc345298");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9822b3f1-7b56-4dac-baa9-6c1fdf77d11c");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49c13023-a56d-40bd-a240-3b5b83a6b260", "f99da1f1-449d-4862-b44c-04db8a27d515", "Admin", "ADMIN" },
                    { "f0fa68fd-23c8-42f9-b0a8-1fad8113b00e", "5bbfa1e5-f70a-4873-ab32-c3153b148e87", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "4835f283-bc9b-4fe1-bb11-2c38ff7bfe6a", 0, "Adminsgatan 1", "Borås", "c178a368-4cd7-4358-9e9b-71f6bfd1ee14", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEGxUNMcRGja4JJsWOFwKjZPZpcanLyjdz9WodUSh5Km+JDwUvgCcrGk6iw1FgUVYZw==", "10101010101", null, false, "96f29405-7a96-4108-9662-24ca84da27f2", false, "admin@n4h.com", "10001" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "49c13023-a56d-40bd-a240-3b5b83a6b260", "4835f283-bc9b-4fe1-bb11-2c38ff7bfe6a" });
        }
    }
}
