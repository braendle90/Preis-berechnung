using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceCalculation.Migrations
{
    public partial class addpriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RangeTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RangeFrom = table.Column<int>(type: "int", nullable: false),
                    RangeTo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TexilId = table.Column<int>(type: "int", nullable: true),
                    NumberColorsId = table.Column<int>(type: "int", nullable: true),
                    RangeId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceTable_Colors_NumberColorsId",
                        column: x => x.NumberColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTable_RangeTable_RangeId",
                        column: x => x.RangeId,
                        principalTable: "RangeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTable_Textils_TexilId",
                        column: x => x.TexilId,
                        principalTable: "Textils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceTable_NumberColorsId",
                table: "PriceTable",
                column: "NumberColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTable_RangeId",
                table: "PriceTable",
                column: "RangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTable_TexilId",
                table: "PriceTable",
                column: "TexilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceTable");

            migrationBuilder.DropTable(
                name: "RangeTable");
        }
    }
}
