using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("579d113a-ca1f-409f-a50f-7581984f8fb0"),
                column: "Url",
                value: "/Admin/Feedback");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("579d113a-ca1f-409f-a50f-7581984f8fb0"),
                column: "Url",
                value: "/Admin/Request/Service");
        }
    }
}
