using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class addBillOrderColumnToSaleDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "BillOrder",
                table: "SaleDetail",
                type: "smallint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillOrder",
                table: "SaleDetail");
        }
    }
}
