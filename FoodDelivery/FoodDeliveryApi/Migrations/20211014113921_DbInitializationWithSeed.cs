using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDeliveryApi.Migrations
{
    public partial class DbInitializationWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(maxLength: 100, nullable: false),
                    Street = table.Column<string>(maxLength: 100, nullable: false),
                    StreetNumber = table.Column<string>(maxLength: 100, nullable: false),
                    Building = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                });

             migrationBuilder.CreateTable(
                 name: "Order",
                 columns: table => new
                 {
                     Id = table.Column<int>(nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     IdUser = table.Column<int>(maxLength: 100, nullable: false),
                     IdRestaurant = table.Column<int>(maxLength: 100, nullable: false),
                     Products = table.Column<string>(nullable: true),
                     Price = table.Column<string>(maxLength: 100, nullable: false),
                     Location = table.Column<string>(maxLength: 100, nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Order", x => x.Id);
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
                 name: "Product",
                 columns: table => new
                 {
                     Id = table.Column<int>(nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     IdRestaurant = table.Column<int>(maxLength: 100, nullable: false),
                     Name = table.Column<string>(maxLength: 100, nullable: false),
                     Price = table.Column<string>(maxLength: 100, nullable: false),
                     Description = table.Column<string>(maxLength: 100, nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Product", x => x.Id);
                     table.ForeignKey(
                         name: "FK_Product_Restaurants_IdRestaurants",
                         column: x => x.IdRestaurant,
                         principalTable: "Restaurants",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                 });




           
             migrationBuilder.InsertData(
                 table: "Restaurants",
                 columns: new[] { "Building", "RestaurantName", "Street", "StreetNumber" },
                 values: new object[] { "Sc.B", "SmilePizza", "Pacurari", "22" });

             migrationBuilder.InsertData(
                 table: "Users",
                 columns: new[] { "Email", "Password", "UserName" },
                 values: new object[] { "mariusd30", "12345", "mariusd30" });

            migrationBuilder.InsertData(
                 table: "Order",
                 columns: new[] { "Id", "IdRestaurant", "IdUser", "Location", "Price", "Products" },
                 values: new object[] { 1, 1, "Pacurari,22", "100", "{'1':2}" });   

            migrationBuilder.InsertData(
                 table: "Product",
                 columns: new[] { "Id", "Description", "IdRestaurant", "Name", "Price" },
                 values: new object[] { "Pizza cu de toate", 1, "Pizza", "10" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}


