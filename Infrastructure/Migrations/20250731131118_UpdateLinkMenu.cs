using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLinkMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("3bd7c475-345a-4f0f-8b6a-8001369c9101"),
                column: "Url",
                value: "/Admin/Request/Service");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("4c773ebb-a00b-4eb7-b275-18e67dc12ad0"),
                columns: new[] { "Order", "Url" },
                values: new object[] { 19, "/Admin/Request/Education" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("3bd7c475-345a-4f0f-8b6a-8001369c9101"),
                column: "Url",
                value: "/Admin/TreatmentCenter");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("4c773ebb-a00b-4eb7-b275-18e67dc12ad0"),
                columns: new[] { "Order", "Url" },
                values: new object[] { 18, "/Admin/TreatmentCenter" });
        }
    }
}
