using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLicenseLogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LicenseLogo",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Setting",
                keyColumn: "Id",
                keyValue: new Guid("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"),
                column: "LicenseLogo",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseLogo",
                schema: "dbo",
                table: "Setting");
        }
    }
}
