using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SelfJoinInPages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentPageId",
                schema: "dbo",
                table: "Page",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Page_ParentPageId",
                schema: "dbo",
                table: "Page",
                column: "ParentPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Page_ParentPageId",
                schema: "dbo",
                table: "Page",
                column: "ParentPageId",
                principalSchema: "dbo",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Page_ParentPageId",
                schema: "dbo",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Page_ParentPageId",
                schema: "dbo",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "ParentPageId",
                schema: "dbo",
                table: "Page");
        }
    }
}
