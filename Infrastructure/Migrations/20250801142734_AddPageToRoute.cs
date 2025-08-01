using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPageToRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "Icon", "Order", "Title", "Url" },
                values: new object[] { new Guid("62d1bb97-11f7-477b-892d-78d300ab77df"), "<i class=\"fas fa-note-sticky menu-icon\"></i>\r\n", 28, "صفحات", "/Admin/Page" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("62d1bb97-11f7-477b-892d-78d300ab77df"));
        }
    }
}
