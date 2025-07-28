using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumntoSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemFourLink",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemFourTitleEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemFourTitleFa",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemOneLink",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemOneTitleEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemOneTitleFa",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemThreeLink",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemThreeTitleEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemThreeTitleFa",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemTwoLink",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemTwoTitleEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneItemTwoTitleFa",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneTitleEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOneTitleFa",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemFourLink",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemFourTitleEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemFourTitleFa",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemOneLink",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemOneTitleEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemOneTitleFa",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemThreeLink",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemThreeTitleEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemThreeTitleFa",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemTwoLink",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemTwoTitleEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoItemTwoTitleFa",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoTitleEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwoTitleFa",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Setting",
                keyColumn: "Id",
                keyValue: new Guid("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"),
                columns: new[] { "ColumnOneItemFourLink", "ColumnOneItemFourTitleEn", "ColumnOneItemFourTitleFa", "ColumnOneItemOneLink", "ColumnOneItemOneTitleEn", "ColumnOneItemOneTitleFa", "ColumnOneItemThreeLink", "ColumnOneItemThreeTitleEn", "ColumnOneItemThreeTitleFa", "ColumnOneItemTwoLink", "ColumnOneItemTwoTitleEn", "ColumnOneItemTwoTitleFa", "ColumnOneTitleEn", "ColumnOneTitleFa", "ColumnTwoItemFourLink", "ColumnTwoItemFourTitleEn", "ColumnTwoItemFourTitleFa", "ColumnTwoItemOneLink", "ColumnTwoItemOneTitleEn", "ColumnTwoItemOneTitleFa", "ColumnTwoItemThreeLink", "ColumnTwoItemThreeTitleEn", "ColumnTwoItemThreeTitleFa", "ColumnTwoItemTwoLink", "ColumnTwoItemTwoTitleEn", "ColumnTwoItemTwoTitleFa", "ColumnTwoTitleEn", "ColumnTwoTitleFa" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnOneItemFourLink",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneItemFourTitleEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneItemFourTitleFa",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneItemOneLink",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneItemOneTitleEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneItemOneTitleFa",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneItemThreeLink",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneItemThreeTitleEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneItemThreeTitleFa",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneItemTwoLink",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneItemTwoTitleEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneItemTwoTitleFa",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneTitleEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnOneTitleFa",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemFourLink",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemFourTitleEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemFourTitleFa",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemOneLink",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemOneTitleEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemOneTitleFa",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemThreeLink",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemThreeTitleEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemThreeTitleFa",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemTwoLink",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemTwoTitleEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoItemTwoTitleFa",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoTitleEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ColumnTwoTitleFa",
                table: "Setting");
        }
    }
}
