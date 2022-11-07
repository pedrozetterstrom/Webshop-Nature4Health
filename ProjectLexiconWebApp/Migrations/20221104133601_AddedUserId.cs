using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLexiconWebApp.Migrations
{
    public partial class AddedUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64656bf0-1d14-45ca-8369-3c2d21568bdb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "243f73b5-62d5-4a71-903f-267050abe7d5", "8b2ddc63-3d40-46f8-ab91-0249cc4ed585" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "243f73b5-62d5-4a71-903f-267050abe7d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b2ddc63-3d40-46f8-ab91-0249cc4ed585");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b149af24-450b-4061-a88d-122d15f6ed6a", "07cb2b42-d674-471d-ac45-8c8ea5409383", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3d928f1-564d-4844-9733-d40e55d6e14d", "ad4970e7-0040-4056-b385-e34f0d938388", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "74131311-c6b8-4c86-b33a-762a402fc1af", 0, "Adminsgatan 1", "Borås", "b6eb036a-19e4-4754-8824-718fadeee3f5", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEE8uiHPbCqw7FPTWak9RjCvrFFe+670Rxwoz2t3z4qoKhIQWN5ylKSDNmYEXwTB9oA==", "10101010101", null, false, "072150df-6087-4833-994d-50dc00880ddc", false, "admin@n4h.com", "10001" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3d928f1-564d-4844-9733-d40e55d6e14d", "74131311-c6b8-4c86-b33a-762a402fc1af" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b149af24-450b-4061-a88d-122d15f6ed6a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c3d928f1-564d-4844-9733-d40e55d6e14d", "74131311-c6b8-4c86-b33a-762a402fc1af" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3d928f1-564d-4844-9733-d40e55d6e14d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "74131311-c6b8-4c86-b33a-762a402fc1af");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "243f73b5-62d5-4a71-903f-267050abe7d5", "af48163a-de52-40ab-abd1-1abeaca9a886", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64656bf0-1d14-45ca-8369-3c2d21568bdb", "e8570f30-33e6-4708-9055-0a1858d5baff", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "8b2ddc63-3d40-46f8-ab91-0249cc4ed585", 0, "Adminsgatan 1", "Borås", "24636beb-2ff2-4364-8cd4-997e389cb29f", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEOcFBWB9+P0wouswTV9Y/Dg4ELouGpW3WbgF92C4nkM9eF7erAwmGOJ1cab3i+uPfg==", "10101010101", null, false, "8e69b4ad-c01e-451a-afd6-9ea97862af13", false, "admin@n4h.com", "10001" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "243f73b5-62d5-4a71-903f-267050abe7d5", "8b2ddc63-3d40-46f8-ab91-0249cc4ed585" });
        }
    }
}
