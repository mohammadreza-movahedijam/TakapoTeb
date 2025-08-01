using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIconPartner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("20cfd69e-b34c-4f6d-9e36-d9877239b3bb"),
                column: "Icon",
                value: "<i class=\"fa fa-users menu-icon\"></i>\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("20cfd69e-b34c-4f6d-9e36-d9877239b3bb"),
                column: "Icon",
                value: "<i class=\"fa-solid fa-images menu-icon\"></i>");
        }
    }
}
