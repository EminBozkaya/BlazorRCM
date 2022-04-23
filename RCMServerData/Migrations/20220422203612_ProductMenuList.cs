using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class ProductMenuList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "MenuListId",
                table: "Product",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductMenuList",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ListName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ProductMenuList_id", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_MenuListId",
                table: "Product",
                column: "MenuListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductMenuList_MenuListId",
                table: "Product",
                column: "MenuListId",
                principalTable: "ProductMenuList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductMenuList_MenuListId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "ProductMenuList");

            migrationBuilder.DropIndex(
                name: "IX_Product_MenuListId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MenuListId",
                table: "Product");
        }
    }
}
