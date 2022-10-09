using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsShop.DAL.Migrations
{
    public partial class CarsShopDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserBirthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Cars_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserBirthday", "UserName", "UserPassword", "UserRole" },
                values: new object[] { 1, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserName1", "3453sdfd", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserBirthday", "UserName", "UserPassword", "UserRole" },
                values: new object[] { 2, new DateTime(1996, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserName2", "435dfgrfgt", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserBirthday", "UserName", "UserPassword", "UserRole" },
                values: new object[] { 3, new DateTime(1987, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserName3", "48efge65", "User" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarID", "CarModel", "Desc", "Img", "Price", "UserID" },
                values: new object[,]
                {
                    { 11, "Tesla", "Electic", "/img/Tesla.png", 23000, 1 },
                    { 12, "Citroen C4 II", "Fuel", "/img/Citroen.png", 6800, 2 },
                    { 13, "Toyota Yaris", "Fuel", "/img/Yaris.jpg", 5400, 2 },
                    { 14, "BMW I3", "Electic", "/img/BMW.png", 16000, 3 },
                    { 15, "Wolkswagen Polo", "Fuel", "/img/Polo.jpg", 9800, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserID",
                table: "Cars",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
