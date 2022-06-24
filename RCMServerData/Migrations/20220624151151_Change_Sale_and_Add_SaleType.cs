using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class Change_Sale_and_Add_SaleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_User_UId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_UId",
                table: "Sale");

            migrationBuilder.AlterColumn<int>(
                name: "UId",
                table: "Sale",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DailyBillOrder",
                table: "Sale",
                type: "int",
                nullable: true)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Sale",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Sale",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsModified",
                table: "Sale",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Sale",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedTime",
                table: "Sale",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "STId",
                table: "Sale",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SaleType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Type = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_DeletedBy",
                table: "Sale",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_STId",
                table: "Sale",
                column: "STId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_SaleType_STId",
                table: "Sale",
                column: "STId",
                principalTable: "SaleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_User_DeletedBy",
                table: "Sale",
                column: "DeletedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_User_ModifiedBy",
                table: "Sale",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_SaleType_STId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_User_DeletedBy",
                table: "Sale");

            migrationBuilder.DropTable(
                name: "SaleType");

            migrationBuilder.DropIndex(
                name: "IX_Sale_DeletedBy",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_STId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "DailyBillOrder",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "IsModified",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ModifiedTime",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "STId",
                table: "Sale");

            migrationBuilder.AlterColumn<int>(
                name: "UId",
                table: "Sale",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_UId",
                table: "Sale",
                column: "UId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_User_UId",
                table: "Sale",
                column: "UId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
