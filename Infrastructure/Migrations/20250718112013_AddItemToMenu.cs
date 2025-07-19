using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddItemToMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "Icon", "Order", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("8fe991ba-68d0-4398-8ca5-9ad25e9fd75d"), "", 16, "تصاویر محصول", "/Admin/ProductImage" },
                    { new Guid("adb33323-9d60-4993-8299-81d37ed3c41c"), "", 15, "مستندات محصول", "/Admin/Document" },
                    { new Guid("b89b74ce-4017-4d02-8e9e-42a0dc4341b7"), "", 17, "مراکز", "/Admin/TreatmentCenter" },
                    { new Guid("faf6eddd-f721-4a8b-9614-7e7223759b58"), "", 14, "ویژگی های محصول", "/Admin/Option" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("8fe991ba-68d0-4398-8ca5-9ad25e9fd75d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("adb33323-9d60-4993-8299-81d37ed3c41c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("b89b74ce-4017-4d02-8e9e-42a0dc4341b7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("faf6eddd-f721-4a8b-9614-7e7223759b58"));
        }
    }
}
