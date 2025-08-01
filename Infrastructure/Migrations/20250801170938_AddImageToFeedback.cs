using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                schema: "dbo",
                table: "Feedback",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("62d1bb97-11f7-477b-892d-78d300ab77df"),
                column: "Icon",
                value: "<i class=\"fa fa-file menu-icon\" aria-hidden=\"true\"></i>\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                schema: "dbo",
                table: "Feedback");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("62d1bb97-11f7-477b-892d-78d300ab77df"),
                column: "Icon",
                value: "<i class=\"fas fa-note-sticky menu-icon\"></i>\r\n");
        }
    }
}
