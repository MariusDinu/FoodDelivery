using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FoodDeliveryApi.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {





            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Building = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRestaurant = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Restaurants_IdRestaurants",
                        column: x => x.IdRestaurant,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
               name: "Orders",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   IdUser = table.Column<int>(type: "int", nullable: false),
                   IdRestaurant = table.Column<int>(type: "int", nullable: false),
                   Price = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                   Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                   CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                   UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Orders", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Order_Users_IdUser",
                       column: x => x.IdUser,
                       principalTable: "Users",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_Order_Restaurants_IdRestaurants",
                       column: x => x.IdRestaurant,
                       principalTable: "Restaurants",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });
            migrationBuilder.CreateTable(
               name: "OrderProducts",
               columns: table => new
               {
                   IdOrder = table.Column<int>(type: "int", nullable: false),
                   IdProduct = table.Column<int>(type: "int", nullable: false),
                   Quantity = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_OrderProducts", x => new { x.IdOrder, x.IdProduct, x.Quantity });
                   table.ForeignKey(
                       name: "FK_OrderProducts_Orders_IdOrder",
                       column: x => x.IdOrder,
                       principalTable: "Orders",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });
            migrationBuilder.CreateIndex(
                          name: "IX_Orders_UserId",
                          table: "Orders",
                          column: "IdUser");
            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                column: "IdRestaurant");
            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedAt",
                table: "Orders",
                column: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
