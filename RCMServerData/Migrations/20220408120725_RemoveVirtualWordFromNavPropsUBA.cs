using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class RemoveVirtualWordFromNavPropsUBA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBranchAuthority",
                table: "UserBranchAuthority");

            migrationBuilder.AddPrimaryKey(
                name: "pk_UserBranchAuthority_id",
                table: "UserBranchAuthority",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_UserBranchAuthority_id",
                table: "UserBranchAuthority");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBranchAuthority",
                table: "UserBranchAuthority",
                column: "Id");
        }
    }
}
