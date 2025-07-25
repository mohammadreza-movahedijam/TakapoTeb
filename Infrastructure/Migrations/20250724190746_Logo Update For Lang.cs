using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LogoUpdateForLang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TopLogoPath",
                table: "Setting",
                newName: "TopLogoPathFa");

            migrationBuilder.RenameColumn(
                name: "BottomLogoPath",
                table: "Setting",
                newName: "TopLogoPathEn");

            migrationBuilder.AddColumn<string>(
                name: "BottomLogoPathEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BottomLogoPathFa",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Setting",
                keyColumn: "Id",
                keyValue: new Guid("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"),
                columns: new[] { "BottomLogoPathEn", "BottomLogoPathFa" },
                values: new object[] { "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BottomLogoPathEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "BottomLogoPathFa",
                table: "Setting");

            migrationBuilder.RenameColumn(
                name: "TopLogoPathFa",
                table: "Setting",
                newName: "TopLogoPath");

            migrationBuilder.RenameColumn(
                name: "TopLogoPathEn",
                table: "Setting",
                newName: "BottomLogoPath");
        }
    }
}
