using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class defineMappingOnSaleTypesForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleType_SaleType_TopSaleTypeId",
                table: "SaleType");

            migrationBuilder.DropIndex(
                name: "IX_SaleType_TopSaleTypeId",
                table: "SaleType");

            migrationBuilder.DropColumn(
                name: "TopSaleTypeId",
                table: "SaleType");

            migrationBuilder.CreateIndex(
                name: "IX_SaleType_TopSTId",
                table: "SaleType",
                column: "TopSTId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubSubSaleTypes_TopSaleType_TopSTId",
                table: "SaleType",
                column: "TopSTId",
                principalTable: "SaleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubSubSaleTypes_TopSaleType_TopSTId",
                table: "SaleType");

            migrationBuilder.DropIndex(
                name: "IX_SaleType_TopSTId",
                table: "SaleType");

            migrationBuilder.AddColumn<short>(
                name: "TopSaleTypeId",
                table: "SaleType",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleType_TopSaleTypeId",
                table: "SaleType",
                column: "TopSaleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleType_SaleType_TopSaleTypeId",
                table: "SaleType",
                column: "TopSaleTypeId",
                principalTable: "SaleType",
                principalColumn: "Id");
        }
    }
}
