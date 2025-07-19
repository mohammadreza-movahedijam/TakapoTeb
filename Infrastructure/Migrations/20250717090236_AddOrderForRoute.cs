
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderForRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "dbo",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("0063a094-6e6b-40ff-b459-9db952afa2d8"),
                column: "Order",
                value: 10);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("04a19910-8314-4909-8ab6-28b01f8d8612"),
                column: "Order",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("13efcf5b-ac2a-4ea7-8dbf-00794f5c3579"),
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("20cfd69e-b34c-4f6d-9e36-d9877239b3bb"),
                column: "Order",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("2b187594-0cd6-4103-a93e-c7ecc35df142"),
                column: "Order",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("5fd23be1-e7bf-4c08-b5d7-2a5df8c41d71"),
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("69d86bce-910a-4410-ae9a-da72409d3047"),
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("7d9a13c7-a233-4551-8b4a-61b4c162ac4a"),
                column: "Order",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("8072a16c-8db7-46dd-a3e4-e41f0ece7a76"),
                column: "Order",
                value: 12);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("92e9b533-395f-40de-bf5c-daf5175174cf"),
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("b8f6c352-571a-4235-9e92-c325db6d6ddf"),
                column: "Order",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c3d18153-b55e-4f50-b64c-93d4f6bea161"),
                column: "Order",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("d71c15ce-8785-4abf-8f5b-d58a1a4e8ca5"),
                column: "Order",
                value: 13);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                schema: "dbo",
                table: "Route");
        }
    }
}
