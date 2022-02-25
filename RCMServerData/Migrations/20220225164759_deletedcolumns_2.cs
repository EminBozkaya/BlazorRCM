using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class deletedcolumns_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deneme",
                table: "AuthorityType");

            migrationBuilder.DropColumn(
                name: "Denemeiki",
                table: "AuthorityType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deneme",
                table: "AuthorityType",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Denemeiki",
                table: "AuthorityType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
