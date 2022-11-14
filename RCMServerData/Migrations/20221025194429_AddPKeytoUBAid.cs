using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class AddPKeytoUBAid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBranchAuthority",
                table: "UserBranchAuthority");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBranchAuthority",
                table: "UserBranchAuthority",
                columns: new[] { "Id", "UId", "BId", "ATId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchAuthority_UId",
                table: "UserBranchAuthority",
                column: "UId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBranchAuthority",
                table: "UserBranchAuthority");

            migrationBuilder.DropIndex(
                name: "IX_UserBranchAuthority_UId",
                table: "UserBranchAuthority");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBranchAuthority",
                table: "UserBranchAuthority",
                columns: new[] { "UId", "BId", "ATId" });
        }
    }
}
