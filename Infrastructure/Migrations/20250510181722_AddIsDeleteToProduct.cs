using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeleteToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "Product",
                table: "Product",
                newName: "TitleFa");

            migrationBuilder.RenameColumn(
                name: "Descrption",
                schema: "Product",
                table: "Product",
                newName: "DescrptionFa");

            migrationBuilder.AddColumn<string>(
                name: "DescrptionEn",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                schema: "Product",
                table: "Product",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescrptionEn",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                schema: "Product",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "TitleFa",
                schema: "Product",
                table: "Product",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "DescrptionFa",
                schema: "Product",
                table: "Product",
                newName: "Descrption");
        }
    }
}
