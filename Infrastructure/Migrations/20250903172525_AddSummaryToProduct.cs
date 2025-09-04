using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSummaryToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescrptionSectionTwoEn",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescrptionSectionTwoFa",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SummaryEn",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SummaryFa",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescrptionSectionTwoEn",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DescrptionSectionTwoFa",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SummaryEn",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SummaryFa",
                schema: "Product",
                table: "Product");
        }
    }
}
