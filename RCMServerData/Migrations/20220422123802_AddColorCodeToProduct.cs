using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class AddColorCodeToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "ColorCode",
                table: "Product",
                type: "smallint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "Product");
        }
    }
}
