using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAcademyToSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademyImagePath",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademyTextEn",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademyTextFa",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademyTitleEn",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademyTitleFa",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Setting",
                keyColumn: "Id",
                keyValue: new Guid("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"),
                columns: new[] { "AcademyImagePath", "AcademyTextEn", "AcademyTextFa", "AcademyTitleEn", "AcademyTitleFa" },
                values: new object[] { "", "", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademyImagePath",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AcademyTextEn",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AcademyTextFa",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AcademyTitleEn",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AcademyTitleFa",
                schema: "dbo",
                table: "Setting");
        }
    }
}
