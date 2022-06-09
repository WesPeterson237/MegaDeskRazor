using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskRazor.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote");

            migrationBuilder.CreateTable(
                name: "DesktopMaterial",
                columns: table => new
                {
                    DesktopMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesktopMaterialName = table.Column<string>(nullable: true),
                    DesktopMaterialPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesktopMaterial", x => x.DesktopMaterialId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote",
                column: "DeskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Desk_DesktopMaterialId",
                table: "Desk",
                column: "DesktopMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desk_DesktopMaterial_DesktopMaterialId",
                table: "Desk",
                column: "DesktopMaterialId",
                principalTable: "DesktopMaterial",
                principalColumn: "DesktopMaterialId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desk_DesktopMaterial_DesktopMaterialId",
                table: "Desk");

            migrationBuilder.DropTable(
                name: "DesktopMaterial");

            migrationBuilder.DropIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote");

            migrationBuilder.DropIndex(
                name: "IX_Desk_DesktopMaterialId",
                table: "Desk");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote",
                column: "DeskId");
        }
    }
}
