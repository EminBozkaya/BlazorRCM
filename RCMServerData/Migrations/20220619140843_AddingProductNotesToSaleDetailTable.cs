using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class AddingProductNotesToSaleDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "firstProductNote",
                table: "SaleDetail",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "generalProductNote",
                table: "SaleDetail",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "secondProductNote",
                table: "SaleDetail",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "thirdProductNote",
                table: "SaleDetail",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstProductNote",
                table: "SaleDetail");

            migrationBuilder.DropColumn(
                name: "generalProductNote",
                table: "SaleDetail");

            migrationBuilder.DropColumn(
                name: "secondProductNote",
                table: "SaleDetail");

            migrationBuilder.DropColumn(
                name: "thirdProductNote",
                table: "SaleDetail");
        }
    }
}
