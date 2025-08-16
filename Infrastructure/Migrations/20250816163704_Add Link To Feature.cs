using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkToFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkFour",
                schema: "dbo",
                table: "Feature",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkOne",
                schema: "dbo",
                table: "Feature",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkThree",
                schema: "dbo",
                table: "Feature",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkTwo",
                schema: "dbo",
                table: "Feature",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"),
                columns: new[] { "LinkFour", "LinkOne", "LinkThree", "LinkTwo" },
                values: new object[] { "#", "#", "#", "#" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkFour",
                schema: "dbo",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "LinkOne",
                schema: "dbo",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "LinkThree",
                schema: "dbo",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "LinkTwo",
                schema: "dbo",
                table: "Feature");
        }
    }
}
