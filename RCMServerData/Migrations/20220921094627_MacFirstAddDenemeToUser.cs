using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class MacFirstAddDenemeToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deneme",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UId",
                table: "Sale",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Sale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ModifiedBy",
                table: "Sale",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_UId",
                table: "Sale",
                column: "UId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_User_ModifiedBy",
                table: "Sale",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Sale_User_ModifiedBy",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_User_UId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_ModifiedBy",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_UId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "Deneme",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "UId",
                table: "Sale",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Sale",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
