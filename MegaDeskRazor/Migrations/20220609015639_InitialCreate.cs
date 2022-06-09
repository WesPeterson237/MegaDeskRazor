using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskRazor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryType",
                columns: table => new
                {
                    DeliveryTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryName = table.Column<string>(nullable: true),
                    PriceUnder1000 = table.Column<decimal>(nullable: false),
                    PriceBetween1000And2000 = table.Column<decimal>(nullable: false),
                    PriceOver2000 = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryType", x => x.DeliveryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    DeskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<int>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    NumberOfDrawers = table.Column<int>(nullable: false),
                    DesktopMaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.DeskId);
                });

            migrationBuilder.CreateTable(
                name: "DeskQuote",
                columns: table => new
                {
                    DeskQuoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    QuoteDate = table.Column<DateTime>(nullable: false),
                    QuotePrice = table.Column<decimal>(nullable: false),
                    DeskId = table.Column<int>(nullable: false),
                    DeliveryTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuote", x => x.DeskQuoteId);
                    table.ForeignKey(
                        name: "FK_DeskQuote_DeliveryType_DeliveryTypeId",
                        column: x => x.DeliveryTypeId,
                        principalTable: "DeliveryType",
                        principalColumn: "DeliveryTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeskQuote_Desk_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desk",
                        principalColumn: "DeskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeliveryTypeId",
                table: "DeskQuote",
                column: "DeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote",
                column: "DeskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuote");

            migrationBuilder.DropTable(
                name: "DeliveryType");

            migrationBuilder.DropTable(
                name: "Desk");
        }
    }
}
