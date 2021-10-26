using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDeliveryApi.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Products",
                table: "Orders",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10000)",
                oldMaxLength: 10000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Products",
                table: "Orders",
                type: "nvarchar(10000)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 10000);
        }
    }
}
