using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceCalculation.Migrations
{
    public partial class db_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostionName",
                table: "Positions",
                newName: "PositionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PositionName",
                table: "Positions",
                newName: "PostionName");
        }
    }
}
