using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLexiconWebApp.Migrations
{
    public partial class addedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1485181a-cc99-4751-ab66-c8adad87c556");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b878dc0b-7625-4315-b6f9-b3a0d74f2c4e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "405d8647-2b62-4162-a3bb-93a3b6f6b113", "45fa3392-cb7e-4344-b6e9-651d03031633" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "405d8647-2b62-4162-a3bb-93a3b6f6b113");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fa3392-cb7e-4344-b6e9-651d03031633");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b970d62-6701-4de2-bddb-3a657beed82b", "4e62a554-11e9-46d0-bb00-60ae73ce7d02", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8ac3ffc-b8ec-4731-aa95-230f2a0c4cc6", "41991a94-899a-4163-b310-7b4090890beb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "dd745e28-585a-4222-b50c-f85d4fc7e54b", 0, "Adminsgatan 1", "Borås", "9aafb88b-f7f1-47c0-a5e4-3a36e0bfba2e", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEBMj+4KPoJZSExyrDIAdgCgYdol+4t6lyvP4cq830i6MZu+m7BYMFEfha32EyKRRGg==", "10101010101", null, false, "eb2b2bae-75b7-4174-ae14-01a067dc3b52", false, "admin@n4h.com", "10001" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0b970d62-6701-4de2-bddb-3a657beed82b", "dd745e28-585a-4222-b50c-f85d4fc7e54b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1485181a-cc99-4751-ab66-c8adad87c556", "712d78ef-6b7a-4ea1-b871-39a7be8cc0d1", "User", "USER" },
                    { "405d8647-2b62-4162-a3bb-93a3b6f6b113", "5fc043ad-adb0-4a2d-b6f4-4557de2a1c52", "Admin", "ADMIN" },
                    { "b878dc0b-7625-4315-b6f9-b3a0d74f2c4e", "08993ccd-e98d-4ba5-bf4c-0072ff6c6384", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "45fa3392-cb7e-4344-b6e9-651d03031633", 0, "Adminsgatan 1", "Borås", "e38cde0c-b31f-467b-b4f1-f8549496c752", "admin@n4h.com", false, "Daniel", "O.", false, null, "ADMIN@N4H.COM", "ADMIN@N4H.COM", "AQAAAAEAACcQAAAAEHwCfxoohMkQOLOtm5GttPpeyOKpTn3msisVb+p9bsQd7HWTti3D7hWK70gAuCPwCA==", "10101010101", null, false, "9c53c632-3c01-49a4-affb-ea623d7d0288", false, "admin@n4h.com", "10001" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "405d8647-2b62-4162-a3bb-93a3b6f6b113", "45fa3392-cb7e-4344-b6e9-651d03031633" });
        }
    }
}
