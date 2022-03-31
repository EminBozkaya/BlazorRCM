﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class FirstMig_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorityType",
                columns: table => new
                {
                    ATId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Type = table.Column<string>(type: "varchar", maxLength: 20, nullable: true)
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Adress = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "current_date"),
                    ModifiedTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Branch_id", x => x.BId);
                });

            migrationBuilder.CreateTable(
                name: "FirmType",
                columns: table => new
                {
                    FTId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_FirmType_id", x => x.FTId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    FirstName = table.Column<string>(type: "varchar", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "varchar", maxLength: 25, nullable: false),
                    UserName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "char(12)", unicode: false, maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "current_date"),
                    ModifiedTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_User_id", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CompanyName = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Adress = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "current_date"),
                    ModifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Supplier_id", x => x.SpId);
                    table.ForeignKey(
                        name: "FK_Supplier_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_User_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBranchAuthority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UId = table.Column<int>(type: "int", nullable: false),
                    BId = table.Column<short>(type: "smallint", nullable: false),
                    ATId = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_UserBranchAuthority_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBranchAuthority_AuthorityType_ATId",
                        column: x => x.ATId,
                        principalTable: "AuthorityType",
                        principalColumn: "ATId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBranchAuthority_Branch_BId",
                        column: x => x.BId,
                        principalTable: "Branch",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBranchAuthority_User_UId",
                        column: x => x.UId,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchSupplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    BId = table.Column<short>(type: "smallint", nullable: false),
                    SpId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "current_date"),
                    ModifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_BranchSupplier_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchSupplier_Branch_BId",
                        column: x => x.BId,
                        principalTable: "Branch",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchSupplier_Supplier_SpId",
                        column: x => x.SpId,
                        principalTable: "Supplier",
                        principalColumn: "SpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchSupplier_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchSupplier_User_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierFirmType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    SpId = table.Column<int>(type: "int", nullable: false),
                    FtId = table.Column<short>(type: "smallint", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "current_date"),
                    ModifiedTime = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_SupplierFirmType_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierFirmType_FirmType_FtId",
                        column: x => x.FtId,
                        principalTable: "FirmType",
                        principalColumn: "FTId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierFirmType_Supplier_SpId",
                        column: x => x.SpId,
                        principalTable: "Supplier",
                        principalColumn: "SpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierFirmType_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierFirmType_User_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchSupplier_BId",
                table: "BranchSupplier",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchSupplier_CreatedBy",
                table: "BranchSupplier",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchSupplier_ModifiedBy",
                table: "BranchSupplier",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchSupplier_SpId",
                table: "BranchSupplier",
                column: "SpId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CreatedBy",
                table: "Supplier",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ModifiedBy",
                table: "Supplier",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierFirmType_FtId",
                table: "SupplierFirmType",
                column: "FtId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierFirmType_CreatedBy",
                table: "SupplierFirmType",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierFirmType_ModifiedBy",
                table: "SupplierFirmType",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierFirmType_SpId",
                table: "SupplierFirmType",
                column: "SpId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchAuthority_ATId",
                table: "UserBranchAuthority",
                column: "ATId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchAuthority_BId",
                table: "UserBranchAuthority",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchAuthority_UId",
                table: "UserBranchAuthority",
                column: "UId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchSupplier");

            migrationBuilder.DropTable(
                name: "SupplierFirmType");

            migrationBuilder.DropTable(
                name: "UserBranchAuthority");

            migrationBuilder.DropTable(
                name: "FirmType");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "AuthorityType");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
