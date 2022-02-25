using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class AddedFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorityType",
                columns: table => new
                {
                    ATId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Deneme = table.Column<string>(type: "varchar", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_AuthorityType_id", x => x.ATId);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "date", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Branch_id", x => x.BId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "date", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_User_id", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "UserBranchAuthority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UId = table.Column<int>(type: "int", nullable: false),
                    BId = table.Column<short>(type: "smallint", nullable: false),
                    ATId = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorityTypeATId = table.Column<short>(type: "smallint", nullable: false),
                    BranchBId = table.Column<short>(type: "smallint", nullable: false),
                    UserUId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_UserBranchAuthority_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBranchAuthority_AuthorityType_AuthorityTypeATId",
                        column: x => x.AuthorityTypeATId,
                        principalTable: "AuthorityType",
                        principalColumn: "ATId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBranchAuthority_Branch_BranchBId",
                        column: x => x.BranchBId,
                        principalTable: "Branch",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBranchAuthority_User_UserUId",
                        column: x => x.UserUId,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchAuthority_AuthorityTypeATId",
                table: "UserBranchAuthority",
                column: "AuthorityTypeATId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchAuthority_BranchBId",
                table: "UserBranchAuthority",
                column: "BranchBId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchAuthority_UserUId",
                table: "UserBranchAuthority",
                column: "UserUId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBranchAuthority");

            migrationBuilder.DropTable(
                name: "AuthorityType");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
