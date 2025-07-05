using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatistic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOne = table.Column<int>(type: "int", nullable: false),
                    TitleFaOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEnOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberTwo = table.Column<int>(type: "int", nullable: false),
                    TitleFaTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEnTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberThree = table.Column<int>(type: "int", nullable: false),
                    TitleFaThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEnThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberFour = table.Column<int>(type: "int", nullable: false),
                    TitleFaFour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEnFour = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Statistic",
                columns: new[] { "Id", "NumberFour", "NumberOne", "NumberThree", "NumberTwo", "TitleEnFour", "TitleEnOne", "TitleEnThree", "TitleEnTwo", "TitleFaFour", "TitleFaOne", "TitleFaThree", "TitleFaTwo" },
                values: new object[] { new Guid("6b067bbc-a472-4683-b1f1-bf44b3aa51f1"), 0, 0, 0, 0, "", "", "", "", "", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistic");
        }
    }
}
