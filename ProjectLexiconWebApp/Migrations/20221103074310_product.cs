using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLexiconWebApp.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "49c13023-a56d-40bd-a240-3b5b83a6b260", "f99da1f1-449d-4862-b44c-04db8a27d515", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0fa68fd-23c8-42f9-b0a8-1fad8113b00e", "5bbfa1e5-f70a-4873-ab32-c3153b148e87", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "4835f283-bc9b-4fe1-bb11-2c38ff7bfe6a", 0, "Adminsgatan 1", "Borås", "c178a368-4cd7-4358-9e9b-71f6bfd1ee14", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEGxUNMcRGja4JJsWOFwKjZPZpcanLyjdz9WodUSh5Km+JDwUvgCcrGk6iw1FgUVYZw==", "10101010101", null, false, "96f29405-7a96-4108-9662-24ca84da27f2", false, "admin@n4h.com", "10001" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "49c13023-a56d-40bd-a240-3b5b83a6b260", "4835f283-bc9b-4fe1-bb11-2c38ff7bfe6a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ee205d3-be7c-4e14-b56c-6628a5c9f85f", "1e2acffe-36d5-43ed-bd81-a5bac461dda0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab3c0b5f-2e06-4ce6-bf85-527da5d5f563", "ddf4a4bb-3826-441f-9e3f-0ba9a8ffdfd5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "4fb5001d-fd58-44af-bc58-ee135968be61", 0, "Adminsgatan 1", "Borås", "1050710b-31e8-42c9-82e8-e47cc5de8281", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEHAZWw6n+KqwIK7VM6iAlJ4/UI0hoCh/QwpeNItItRfrvPJ/5/HnV2crhVkXvLC4cQ==", "10101010101", null, false, "a4f40b22-df97-4df4-b959-902fc0e1c9cf", false, "admin@n4h.com", "10001" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2ee205d3-be7c-4e14-b56c-6628a5c9f85f", "4fb5001d-fd58-44af-bc58-ee135968be61" });
        }
    }
}
