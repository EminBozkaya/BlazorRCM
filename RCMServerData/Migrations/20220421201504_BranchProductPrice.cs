using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class BranchProductPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchProductPrice",
                columns: table => new
                {
                    BId = table.Column<short>(type: "smallint", nullable: false),
                    PId = table.Column<short>(type: "smallint", nullable: false),
                    BranchPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    VATpercent = table.Column<decimal>(type: "numeric", nullable: true),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchProductPrice", x => new { x.BId, x.PId });
                    table.ForeignKey(
                        name: "FK_BranchProductPrice_Branch_BId",
                        column: x => x.BId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchProductPrice_Product_PId",
                        column: x => x.PId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchProductPrice_PId",
                table: "BranchProductPrice",
                column: "PId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchProductPrice");
        }
    }
}
