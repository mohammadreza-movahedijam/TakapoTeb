using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DynamicColorAndButtonProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ButtonEn",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ButtonFa",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ButtonLink",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorFrom",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorTo",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                schema: "Product",
                table: "Product",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ButtonEn",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ButtonFa",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ButtonLink",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ColorFrom",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ColorTo",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "Product",
                table: "Product");
        }
    }
}
