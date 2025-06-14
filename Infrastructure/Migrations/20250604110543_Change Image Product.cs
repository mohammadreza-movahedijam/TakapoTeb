using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "Product",
                table: "Image",
                newName: "TitleFa");

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                schema: "Product",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleEn",
                schema: "Product",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "TitleFa",
                schema: "Product",
                table: "Image",
                newName: "Title");
        }
    }
}
