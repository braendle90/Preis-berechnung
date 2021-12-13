using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceCalculation.Migrations
{
    public partial class addApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OPLID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OPLID",
                table: "AspNetUsers");
        }
    }
}
