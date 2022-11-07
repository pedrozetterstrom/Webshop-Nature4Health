using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLexiconWebApp.Migrations
{
    public partial class addeduseridincustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b0f431e-1483-4c79-82f0-aaa2bc21b6a7", "113f65e7-29b3-4f4d-9051-b0926f2e5eb1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65b10733-1532-4afb-b973-2fc1ee757244", "acc09603-4e4e-4f82-a6d3-f9e6913fc57d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "83f2d367-3882-485a-980e-301340dbe8ba", 0, "Adminsgatan 1", "Borås", "c7bd49e2-ceaf-4645-ac35-7f4cb75ba08f", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEPQgJg5JlmeJlOgpEFZx0nsTXnSAVusbvur00LC/SUQIgqYXc3gONdXXot/fzSyiUQ==", "10101010101", null, false, "35a75e25-7c00-4b14-a7ab-9b6a9105b7b1", false, "admin@n4h.com", "10001" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "65b10733-1532-4afb-b973-2fc1ee757244", "83f2d367-3882-485a-980e-301340dbe8ba" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b0f431e-1483-4c79-82f0-aaa2bc21b6a7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65b10733-1532-4afb-b973-2fc1ee757244", "83f2d367-3882-485a-980e-301340dbe8ba" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65b10733-1532-4afb-b973-2fc1ee757244");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83f2d367-3882-485a-980e-301340dbe8ba");

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
    }
}
