﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class ReUBA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserBranchAuthority");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserBranchAuthority",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
