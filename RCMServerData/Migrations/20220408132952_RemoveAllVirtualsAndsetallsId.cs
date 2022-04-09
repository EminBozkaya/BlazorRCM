using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class RemoveAllVirtualsAndsetallsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SpId",
                table: "Supplier",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FTId",
                table: "FirmType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BId",
                table: "Branch",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ATId",
                table: "AuthorityType",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Supplier",
                newName: "SpId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FirmType",
                newName: "FTId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Branch",
                newName: "BId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AuthorityType",
                newName: "ATId");
        }
    }
}
