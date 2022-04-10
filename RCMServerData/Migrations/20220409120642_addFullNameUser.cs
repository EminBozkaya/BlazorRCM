using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCMServerData.Migrations
{
    public partial class addFullNameUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserBranchAuthority",
                newName: "UserBranchAuthorities");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "SupplierFirmType",
                newName: "SupplierFirmTypes");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "FirmType",
                newName: "FirmTypes");

            migrationBuilder.RenameTable(
                name: "BranchSupplier",
                newName: "BranchSuppliers");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "Branches");

            migrationBuilder.RenameTable(
                name: "AuthorityType",
                newName: "AuthorityTypes");

            migrationBuilder.RenameIndex(
                name: "IX_UserBranchAuthority_UId",
                table: "UserBranchAuthorities",
                newName: "IX_UserBranchAuthorities_UId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBranchAuthority_BId",
                table: "UserBranchAuthorities",
                newName: "IX_UserBranchAuthorities_BId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBranchAuthority_ATId",
                table: "UserBranchAuthorities",
                newName: "IX_UserBranchAuthorities_ATId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierFirmType_SpId",
                table: "SupplierFirmTypes",
                newName: "IX_SupplierFirmTypes_SpId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierFirmType_ModifiedBy",
                table: "SupplierFirmTypes",
                newName: "IX_SupplierFirmTypes_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierFirmType_FtId",
                table: "SupplierFirmTypes",
                newName: "IX_SupplierFirmTypes_FtId");

            migrationBuilder.RenameIndex(
                name: "IX_Supplier_ModifiedBy",
                table: "Suppliers",
                newName: "IX_Suppliers_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_BranchSupplier_SpId",
                table: "BranchSuppliers",
                newName: "IX_BranchSuppliers_SpId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchSupplier_ModifiedBy",
                table: "BranchSuppliers",
                newName: "IX_BranchSuppliers_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_BranchSupplier_BId",
                table: "BranchSuppliers",
                newName: "IX_BranchSuppliers_BId");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UserBranchAuthorities",
                newName: "UserBranchAuthority");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "SupplierFirmTypes",
                newName: "SupplierFirmType");

            migrationBuilder.RenameTable(
                name: "FirmTypes",
                newName: "FirmType");

            migrationBuilder.RenameTable(
                name: "BranchSuppliers",
                newName: "BranchSupplier");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "Branch");

            migrationBuilder.RenameTable(
                name: "AuthorityTypes",
                newName: "AuthorityType");

            migrationBuilder.RenameIndex(
                name: "IX_UserBranchAuthorities_UId",
                table: "UserBranchAuthority",
                newName: "IX_UserBranchAuthority_UId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBranchAuthorities_BId",
                table: "UserBranchAuthority",
                newName: "IX_UserBranchAuthority_BId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBranchAuthorities_ATId",
                table: "UserBranchAuthority",
                newName: "IX_UserBranchAuthority_ATId");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_ModifiedBy",
                table: "Supplier",
                newName: "IX_Supplier_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierFirmTypes_SpId",
                table: "SupplierFirmType",
                newName: "IX_SupplierFirmType_SpId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierFirmTypes_ModifiedBy",
                table: "SupplierFirmType",
                newName: "IX_SupplierFirmType_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierFirmTypes_FtId",
                table: "SupplierFirmType",
                newName: "IX_SupplierFirmType_FtId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchSuppliers_SpId",
                table: "BranchSupplier",
                newName: "IX_BranchSupplier_SpId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchSuppliers_ModifiedBy",
                table: "BranchSupplier",
                newName: "IX_BranchSupplier_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_BranchSuppliers_BId",
                table: "BranchSupplier",
                newName: "IX_BranchSupplier_BId");
        }
    }
}
