using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkToAcademy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademyButtonTextEn",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademyButtonTextFa",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademyColor",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademyLink",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Setting",
                keyColumn: "Id",
                keyValue: new Guid("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"),
                columns: new[] { "AcademyButtonTextEn", "AcademyButtonTextFa", "AcademyColor", "AcademyLink" },
                values: new object[] { null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademyButtonTextEn",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AcademyButtonTextFa",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AcademyColor",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AcademyLink",
                schema: "dbo",
                table: "Setting");
        }
    }
}
