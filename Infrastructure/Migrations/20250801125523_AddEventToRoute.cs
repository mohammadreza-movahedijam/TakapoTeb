using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEventToRoute : Migration
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
                    { new Guid("0a007642-8260-4199-b18f-9e0a97dcfffd"), "<i class=\"fa fa-calendar menu-icon\" aria-hidden=\"true\"></i>\r\n", 25, "رویدادها", "/Admin/Event" },
                    { new Guid("70c72f87-6463-41fe-b751-25a2acfecaea"), "", 26, "ویدئوهای رویداد", "/Admin/Video" },
                    { new Guid("d2434681-faa3-4937-9bd7-fb8a7b7bd447"), "", 27, "تصاویر رویداد", "/Admin/Picture" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("0a007642-8260-4199-b18f-9e0a97dcfffd"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("70c72f87-6463-41fe-b751-25a2acfecaea"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("d2434681-faa3-4937-9bd7-fb8a7b7bd447"));
        }
    }
}
