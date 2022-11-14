using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class ChangeUserBranchAuthority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_UserBranchAuthority_id",
                table: "UserBranchAuthority");

            migrationBuilder.DropIndex(
                name: "IX_UserBranchAuthority_UId",
                table: "UserBranchAuthority");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserBranchAuthority");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBranchAuthority",
                table: "UserBranchAuthority",
                columns: new[] { "UId", "BId", "ATId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBranchAuthority",
                table: "UserBranchAuthority");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserBranchAuthority",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_UserBranchAuthority_id",
                table: "UserBranchAuthority",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchAuthority_UId",
                table: "UserBranchAuthority",
                column: "UId");
        }
    }
}
