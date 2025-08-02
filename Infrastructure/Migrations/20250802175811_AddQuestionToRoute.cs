using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionToRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "Icon", "Order", "Title", "Url" },
                values: new object[] { new Guid("efc3f43b-c8e1-4f13-bea2-4438a0041032"), "<i class=\"fas fa-question-circle menu-icon\"></i>", 29, "سوالات", "/Admin/Question" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("efc3f43b-c8e1-4f13-bea2-4438a0041032"));
        }
    }
}
