using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutDescriptionEn",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutDescriptionFa",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutImage",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutTitleEn",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutTitleFa",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Setting",
                keyColumn: "Id",
                keyValue: new Guid("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"),
                columns: new[] { "AboutDescriptionEn", "AboutDescriptionFa", "AboutImage", "AboutTitleEn", "AboutTitleFa" },
                values: new object[] { "", "", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutDescriptionEn",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AboutDescriptionFa",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AboutImage",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AboutTitleEn",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AboutTitleFa",
                schema: "dbo",
                table: "Setting");
        }
    }
}
