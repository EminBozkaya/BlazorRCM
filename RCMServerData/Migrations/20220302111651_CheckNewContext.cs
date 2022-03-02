using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class CheckNewContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Branch_BranchBId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_User_UserUId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranchAuthority_AuthorityType_AuthorityTypeATId",
                table: "UserBranchAuthority");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranchAuthority_Branch_BranchBId",
                table: "UserBranchAuthority");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranchAuthority_User_UserUId",
                table: "UserBranchAuthority");

            migrationBuilder.AlterColumn<int>(
                name: "UserUId",
                table: "UserBranchAuthority",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "BranchBId",
                table: "UserBranchAuthority",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "AuthorityTypeATId",
                table: "UserBranchAuthority",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "User",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "User",
                type: "date",
                nullable: false,
                defaultValueSql: "current_date",
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true,
                oldDefaultValueSql: "current_date");

            migrationBuilder.AlterColumn<int>(
                name: "UserUId",
                table: "Supplier",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Supplier",
                type: "varchar",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Supplier",
                type: "varchar",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Supplier",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentDept",
                table: "Supplier",
                type: "numeric(19,4)",
                precision: 19,
                scale: 4,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(19,4)",
                oldPrecision: 19,
                oldScale: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Supplier",
                type: "varchar",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<short>(
                name: "BranchBId",
                table: "Supplier",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Supplier",
                type: "varchar",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Branch",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Branch",
                type: "date",
                nullable: false,
                defaultValueSql: "current_date",
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true,
                oldDefaultValueSql: "current_date");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Branch",
                type: "varchar",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "AuthorityType",
                type: "varchar",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Branch_BranchBId",
                table: "Supplier",
                column: "BranchBId",
                principalTable: "Branch",
                principalColumn: "BId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_User_UserUId",
                table: "Supplier",
                column: "UserUId",
                principalTable: "User",
                principalColumn: "UId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranchAuthority_AuthorityType_AuthorityTypeATId",
                table: "UserBranchAuthority",
                column: "AuthorityTypeATId",
                principalTable: "AuthorityType",
                principalColumn: "ATId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranchAuthority_Branch_BranchBId",
                table: "UserBranchAuthority",
                column: "BranchBId",
                principalTable: "Branch",
                principalColumn: "BId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranchAuthority_User_UserUId",
                table: "UserBranchAuthority",
                column: "UserUId",
                principalTable: "User",
                principalColumn: "UId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Branch_BranchBId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_User_UserUId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranchAuthority_AuthorityType_AuthorityTypeATId",
                table: "UserBranchAuthority");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranchAuthority_Branch_BranchBId",
                table: "UserBranchAuthority");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranchAuthority_User_UserUId",
                table: "UserBranchAuthority");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Branch");

            migrationBuilder.AlterColumn<int>(
                name: "UserUId",
                table: "UserBranchAuthority",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "BranchBId",
                table: "UserBranchAuthority",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "AuthorityTypeATId",
                table: "UserBranchAuthority",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "User",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "User",
                type: "date",
                nullable: true,
                defaultValueSql: "current_date",
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "current_date");

            migrationBuilder.AlterColumn<int>(
                name: "UserUId",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Supplier",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Supplier",
                type: "varchar",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Supplier",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Supplier",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentDept",
                table: "Supplier",
                type: "numeric(19,4)",
                precision: 19,
                scale: 4,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(19,4)",
                oldPrecision: 19,
                oldScale: 4);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Supplier",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "BranchBId",
                table: "Supplier",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Supplier",
                type: "varchar",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Branch",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Branch",
                type: "date",
                nullable: true,
                defaultValueSql: "current_date",
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "current_date");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "AuthorityType",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Branch_BranchBId",
                table: "Supplier",
                column: "BranchBId",
                principalTable: "Branch",
                principalColumn: "BId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_User_UserUId",
                table: "Supplier",
                column: "UserUId",
                principalTable: "User",
                principalColumn: "UId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranchAuthority_AuthorityType_AuthorityTypeATId",
                table: "UserBranchAuthority",
                column: "AuthorityTypeATId",
                principalTable: "AuthorityType",
                principalColumn: "ATId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranchAuthority_Branch_BranchBId",
                table: "UserBranchAuthority",
                column: "BranchBId",
                principalTable: "Branch",
                principalColumn: "BId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranchAuthority_User_UserUId",
                table: "UserBranchAuthority",
                column: "UserUId",
                principalTable: "User",
                principalColumn: "UId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
