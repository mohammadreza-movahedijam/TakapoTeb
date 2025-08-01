using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
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
                    { new Guid("3340131a-42eb-448e-87b8-be6f2cf0baed"), "<i class=\"fas fa-list-alt menu-icon\"></i>\r\n", 22, "دسته بندی مقالات", "/Admin/BlogCategory" },
                    { new Guid("67d20d6a-cf73-4150-b9ce-0cb3bc83a8c8"), "<i class=\"fas fa-list-alt menu-icon\"></i>\r\n", 24, "دسته بندی محصولات", "/Admin/ProductCategory" },
                    { new Guid("a7a03bed-1848-4a26-b886-df2efef5271d"), "<i class=\"fas fa-list-alt menu-icon\"></i>\r\n", 23, "دسته بندی اخبار", "/Admin/NewsCategory" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("3340131a-42eb-448e-87b8-be6f2cf0baed"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("67d20d6a-cf73-4150-b9ce-0cb3bc83a8c8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("a7a03bed-1848-4a26-b886-df2efef5271d"));
        }
    }
}
