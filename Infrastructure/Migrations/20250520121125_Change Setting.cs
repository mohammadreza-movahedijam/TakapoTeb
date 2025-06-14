using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "About",
                table: "Setting",
                newName: "AboutFa");

            migrationBuilder.AddColumn<string>(
                name: "AboutEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Setting",
                keyColumn: "Id",
                keyValue: new Guid("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"),
                column: "AboutEn",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutEn",
                table: "Setting");

            migrationBuilder.RenameColumn(
                name: "AboutFa",
                table: "Setting",
                newName: "About");
        }
    }
}
