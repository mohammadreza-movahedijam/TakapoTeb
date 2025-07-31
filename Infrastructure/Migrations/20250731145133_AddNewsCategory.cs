using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Statistic",
                newName: "Statistic",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Slider",
                newName: "Slider",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Setting",
                newName: "Setting",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RequestServiceAttach",
                newName: "RequestServiceAttach",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RequestService",
                newName: "RequestService",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RequestEducationAttach",
                newName: "RequestEducationAttach",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RequestEducation",
                newName: "RequestEducation",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Partner",
                newName: "Partner",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "News",
                newName: "News",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Message",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Feedback",
                newName: "Feedback",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Feature",
                newName: "Feature",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Departement",
                newName: "Departement",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ChatGroup",
                newName: "ChatGroup",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Catalog",
                newName: "Catalog",
                newSchema: "dbo");

            migrationBuilder.AddColumn<Guid>(
                name: "NewsCategoryId",
                schema: "dbo",
                table: "News",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "NewsCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategory", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "Icon", "Order", "Title", "Url" },
                values: new object[] { new Guid("579d113a-ca1f-409f-a50f-7581984f8fb0"), "<i class=\"fa fa-comment menu-icon\"></i>", 21, "دیدگاه کاربران", "/Admin/Request/Service" });

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsCategoryId",
                schema: "dbo",
                table: "News",
                column: "NewsCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategory_NewsCategoryId",
                schema: "dbo",
                table: "News",
                column: "NewsCategoryId",
                principalSchema: "dbo",
                principalTable: "NewsCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategory_NewsCategoryId",
                schema: "dbo",
                table: "News");

            migrationBuilder.DropTable(
                name: "NewsCategory",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_News_NewsCategoryId",
                schema: "dbo",
                table: "News");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("579d113a-ca1f-409f-a50f-7581984f8fb0"));

            migrationBuilder.DropColumn(
                name: "NewsCategoryId",
                schema: "dbo",
                table: "News");

            migrationBuilder.RenameTable(
                name: "Statistic",
                schema: "dbo",
                newName: "Statistic");

            migrationBuilder.RenameTable(
                name: "Slider",
                schema: "dbo",
                newName: "Slider");

            migrationBuilder.RenameTable(
                name: "Setting",
                schema: "dbo",
                newName: "Setting");

            migrationBuilder.RenameTable(
                name: "RequestServiceAttach",
                schema: "dbo",
                newName: "RequestServiceAttach");

            migrationBuilder.RenameTable(
                name: "RequestService",
                schema: "dbo",
                newName: "RequestService");

            migrationBuilder.RenameTable(
                name: "RequestEducationAttach",
                schema: "dbo",
                newName: "RequestEducationAttach");

            migrationBuilder.RenameTable(
                name: "RequestEducation",
                schema: "dbo",
                newName: "RequestEducation");

            migrationBuilder.RenameTable(
                name: "Partner",
                schema: "dbo",
                newName: "Partner");

            migrationBuilder.RenameTable(
                name: "News",
                schema: "dbo",
                newName: "News");

            migrationBuilder.RenameTable(
                name: "Message",
                schema: "dbo",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "Feedback",
                schema: "dbo",
                newName: "Feedback");

            migrationBuilder.RenameTable(
                name: "Feature",
                schema: "dbo",
                newName: "Feature");

            migrationBuilder.RenameTable(
                name: "Departement",
                schema: "dbo",
                newName: "Departement");

            migrationBuilder.RenameTable(
                name: "ChatGroup",
                schema: "dbo",
                newName: "ChatGroup");

            migrationBuilder.RenameTable(
                name: "Catalog",
                schema: "dbo",
                newName: "Catalog");
        }
    }
}
