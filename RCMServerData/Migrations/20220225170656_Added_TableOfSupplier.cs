using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class Added_TableOfSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    FTId = table.Column<byte>(type: "smallint", nullable: false),
                    CurrentDept = table.Column<decimal>(type: "numeric(19,4)", precision: 19, scale: 4, nullable: true),
                    Adress = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    CompanyName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "date", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SpId);
                });

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier");

        }
    }
}
