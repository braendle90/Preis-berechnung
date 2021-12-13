using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceCalculation.Migrations
{
    public partial class addApplicationUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OrderPositionLogos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nachname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vorname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositionLogos_UserId",
                table: "OrderPositionLogos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPositionLogos_AspNetUsers_UserId",
                table: "OrderPositionLogos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPositionLogos_AspNetUsers_UserId",
                table: "OrderPositionLogos");

            migrationBuilder.DropIndex(
                name: "IX_OrderPositionLogos_UserId",
                table: "OrderPositionLogos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderPositionLogos");

            migrationBuilder.DropColumn(
                name: "Nachname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Vorname",
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
    }
}
