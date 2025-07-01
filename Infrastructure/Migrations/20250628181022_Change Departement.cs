using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDepartement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Departement",
                newName: "PhoneNumberFa");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberEn",
                table: "Departement",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumberEn",
                table: "Departement");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberFa",
                table: "Departement",
                newName: "PhoneNumber");
        }
    }
}
