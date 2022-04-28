using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class ProductSaleNoteCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "NoteCat",
                table: "ProductSaleNote",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductSaleNoteCategory",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    NotCat = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSaleNoteCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaleNote_NoteCat",
                table: "ProductSaleNote",
                column: "NoteCat");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSaleNote_ProductSaleNoteCategory_NoteCat",
                table: "ProductSaleNote",
                column: "NoteCat",
                principalTable: "ProductSaleNoteCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSaleNote_ProductSaleNoteCategory_NoteCat",
                table: "ProductSaleNote");

            migrationBuilder.DropTable(
                name: "ProductSaleNoteCategory");

            migrationBuilder.DropIndex(
                name: "IX_ProductSaleNote_NoteCat",
                table: "ProductSaleNote");

            migrationBuilder.DropColumn(
                name: "NoteCat",
                table: "ProductSaleNote");
        }
    }
}
