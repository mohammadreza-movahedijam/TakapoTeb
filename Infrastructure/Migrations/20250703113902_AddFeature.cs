using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEnOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEnTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEnThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEnFour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleFaOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleFaTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleFaThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleFaFour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextEnOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextEnTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextEnThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextEnFour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFaOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFaTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFaThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFaFour = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "ImageFour", "ImageOne", "ImageThree", "ImageTwo", "TextEnFour", "TextEnOne", "TextEnThree", "TextEnTwo", "TextFaFour", "TextFaOne", "TextFaThree", "TextFaTwo", "TitleEnFour", "TitleEnOne", "TitleEnThree", "TitleEnTwo", "TitleFaFour", "TitleFaOne", "TitleFaThree", "TitleFaTwo" },
                values: new object[] { new Guid("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feature");
        }
    }
}
