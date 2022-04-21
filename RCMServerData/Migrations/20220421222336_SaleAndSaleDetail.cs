using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class SaleAndSaleDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    BId = table.Column<short>(type: "smallint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    UId = table.Column<int>(type: "int", nullable: false),
                    SaleNote = table.Column<string>(type: "text", nullable: true),
                    IsEOD = table.Column<bool>(type: "boolean", nullable: false),
                    EOD = table.Column<DateOnly>(type: "date", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Branch_BId",
                        column: x => x.BId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_User_UId",
                        column: x => x.UId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "UUID_GENERATE_V4()"),
                    SId = table.Column<int>(type: "int", nullable: false),
                    PId = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Portion = table.Column<decimal>(type: "numeric", nullable: false),
                    Qty = table.Column<short>(type: "smallint", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Product_PId",
                        column: x => x.PId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Sale_SId",
                        column: x => x.SId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetail_User_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_BId",
                table: "Sale",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_UId",
                table: "Sale",
                column: "UId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_ModifiedBy",
                table: "SaleDetail",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_PId",
                table: "SaleDetail",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_SId",
                table: "SaleDetail",
                column: "SId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleDetail");

            migrationBuilder.DropTable(
                name: "Sale");
        }
    }
}
