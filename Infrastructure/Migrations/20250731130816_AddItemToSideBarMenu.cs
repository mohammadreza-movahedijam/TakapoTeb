using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddItemToSideBarMenu : Migration
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
                    { new Guid("3bd7c475-345a-4f0f-8b6a-8001369c9101"), "<i class=\"fas fa-code-pull-request menu-icon\"></i>\r\n", 20, "درخواست سرویس", "/Admin/TreatmentCenter" },
                    { new Guid("4c773ebb-a00b-4eb7-b275-18e67dc12ad0"), "<i class=\"fa fa-graduation-cap menu-icon\"></i>\r\n", 18, "درخواست آموزش", "/Admin/TreatmentCenter" },
                    { new Guid("e7f43df3-5a79-4d69-b1f0-bb7badae1662"), "<i class=\"fa fa-folder menu-icon\"></i>\r\n", 18, "کاتالوگ و کتاب کار", "/Admin/Catalog" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("3bd7c475-345a-4f0f-8b6a-8001369c9101"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("4c773ebb-a00b-4eb7-b275-18e67dc12ad0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("e7f43df3-5a79-4d69-b1f0-bb7badae1662"));
        }
    }
}
