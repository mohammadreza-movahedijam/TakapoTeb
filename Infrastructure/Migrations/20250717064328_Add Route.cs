using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleRouteMap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRouteMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleRouteMap_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleRouteMap_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "Icon", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("0063a094-6e6b-40ff-b459-9db952afa2d8"), "<i class=\"fa-solid fa-building menu-icon\"></i>", "واحد های اداری", "/Admin/Departement" },
                    { new Guid("04a19910-8314-4909-8ab6-28b01f8d8612"), "<i class=\"fa-solid fa-headset menu-icon\"></i>", "گفتگوی آنلاین", "/Admin/Chat" },
                    { new Guid("13efcf5b-ac2a-4ea7-8dbf-00794f5c3579"), "<i class=\"fa-solid fa-user-tie menu-icon\"></i>", "مدیریت کاربران", "/Admin/User" },
                    { new Guid("20cfd69e-b34c-4f6d-9e36-d9877239b3bb"), "<i class=\"fa-solid fa-images menu-icon\"></i>", "مدیریت شرکای تجاری", "/Admin/Partner" },
                    { new Guid("2b187594-0cd6-4103-a93e-c7ecc35df142"), "<i class=\"fa-solid fa-envelope menu-icon\"></i>", "پیام ها", "/Admin/Contact" },
                    { new Guid("5fd23be1-e7bf-4c08-b5d7-2a5df8c41d71"), "<i class=\"fa-solid fa-store  menu-icon\"></i>", "مدیریت محصولات", "/Admin/Product" },
                    { new Guid("69d86bce-910a-4410-ae9a-da72409d3047"), "<i class=\"fa-solid fa-pen-nib menu-icon\"></i>", "مدیریت مقالات", "/Admin/Article" },
                    { new Guid("7d9a13c7-a233-4551-8b4a-61b4c162ac4a"), "<i class=\"fas fa-sticky-note menu-icon\"></i>", "مدیریت اخبار", "/Admin/News" },
                    { new Guid("8072a16c-8db7-46dd-a3e4-e41f0ece7a76"), "<i class=\"fa-solid fa-chart-bar  menu-icon\"></i>", "آمار", "/Admin/Setting/Statistic" },
                    { new Guid("92e9b533-395f-40de-bf5c-daf5175174cf"), "<i class=\"fa-solid fa-medal menu-icon\"></i>", "مدیریت نقش", "/Admin/Role" },
                    { new Guid("b8f6c352-571a-4235-9e92-c325db6d6ddf"), "<i class=\"fa-solid fa-wrench  menu-icon\"></i>", "تنظیمات عمومی", "/Admin/Setting/General" },
                    { new Guid("c3d18153-b55e-4f50-b64c-93d4f6bea161"), "<i class=\"fa-solid fa-images menu-icon\"></i>", "مدیریت اسلایدر", "/Admin/Slider" },
                    { new Guid("d71c15ce-8785-4abf-8f5b-d58a1a4e8ca5"), "<i class=\"fa-solid fa-star  menu-icon\"></i>", "آمار", "/Admin/Setting/Feature" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleRouteMap_RoleId",
                table: "RoleRouteMap",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRouteMap_RouteId",
                table: "RoleRouteMap",
                column: "RouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleRouteMap");

            migrationBuilder.DropTable(
                name: "Route");
        }
    }
}
