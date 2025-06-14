using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationEnToSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Setting",
                newName: "LocationFa");

            migrationBuilder.AddColumn<string>(
                name: "LocationEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Setting",
                keyColumn: "Id",
                keyValue: new Guid("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"),
                column: "LocationEn",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationEn",
                table: "Setting");

            migrationBuilder.RenameColumn(
                name: "LocationFa",
                table: "Setting",
                newName: "Location");
        }
    }
}
