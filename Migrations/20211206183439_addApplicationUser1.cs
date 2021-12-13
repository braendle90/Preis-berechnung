using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceCalculation.Migrations
{
    public partial class addApplicationUser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OPLID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "OPLIDId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OPLIDId",
                table: "AspNetUsers",
                column: "OPLIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_OrderPositionLogos_OPLIDId",
                table: "AspNetUsers",
                column: "OPLIDId",
                principalTable: "OrderPositionLogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_OrderPositionLogos_OPLIDId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OPLIDId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OPLIDId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "OPLID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
