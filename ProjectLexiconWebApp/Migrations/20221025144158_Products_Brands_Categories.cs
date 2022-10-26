using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLexiconWebApp.Migrations
{
    public partial class Products_Brands_Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New Foods" },
                    { 2, "Holistic" },
                    { 3, "Happy Green" },
                    { 4, "RawFood" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nuts and seeds" },
                    { 2, "Drink" },
                    { 3, "Tea" },
                    { 4, "Sweeteners" },
                    { 5, "Food" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "Name", "Picture", "Price", "ProductRate", "Quantity", "Size" },
                values: new object[,]
                {
                    { 1, 4, "", 0.0m, "Honey", null, 34.5m, 8.0, 20, "100g" },
                    { 2, 1, "", 0.0m, "Macadamia nuts", null, 132.35m, 8.0, 20, "100g" },
                    { 3, 5, "", 0.0m, "Granola", null, 80.6m, 8.0, 20, "500g" },
                    { 4, 3, "", 0.0m, "Chamomile", null, 60.00m, 3.0, 20, "100g" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
