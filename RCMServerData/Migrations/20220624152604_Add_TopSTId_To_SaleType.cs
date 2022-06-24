using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class Add_TopSTId_To_SaleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SaleType",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "TopSTId",
                table: "SaleType",
                type: "smallint",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_User_UId",
                table: "Sale",
                column: "UId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleType_SaleType_TopSaleTypeId",
                table: "SaleType");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_User_UId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_SaleType_TopSaleTypeId",
                table: "SaleType");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SaleType");

            migrationBuilder.DropColumn(
                name: "TopSTId",
                table: "SaleType");

            migrationBuilder.DropColumn(
                name: "TopSaleTypeId",
                table: "SaleType");
        }
    }
}
