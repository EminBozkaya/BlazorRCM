﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RCMServerData.EFContext;

#nullable disable

namespace RCMServerData.Migrations
{
    [DbContext(typeof(RCMBlazorContext))]
    [Migration("20221025105409_ChangeUserBranchAuthority")]
    partial class ChangeUserBranchAuthority
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RCMServerData.Models.AuthorityType", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("Id"));

                    b.Property<string>("Type")
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("Type");

                    b.HasKey("Id")
                        .HasName("pk_AuthorityType_id");

                    b.ToTable("AuthorityType");
                });

            modelBuilder.Entity("RCMServerData.Models.Branch", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar")
                        .HasColumnName("Adress");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("CreatedTime")
                        .HasDefaultValueSql("current_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("date")
                        .HasColumnName("ModifiedTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("pk_Branch_id");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("RCMServerData.Models.BranchProductPrice", b =>
                {
                    b.Property<short>("BId")
                        .HasColumnType("smallint");

                    b.Property<short>("PId")
                        .HasColumnType("smallint");

                    b.Property<decimal>("BranchPrice")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsFavorite")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("VATpercent")
                        .HasColumnType("numeric");

                    b.HasKey("BId", "PId");

                    b.HasIndex("PId");

                    b.ToTable("BranchProductPrice");
                });

            modelBuilder.Entity("RCMServerData.Models.BranchSupplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<short>("BId")
                        .HasColumnType("smallint")
                        .HasColumnName("BId");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("CreatedTime")
                        .HasDefaultValueSql("current_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("date")
                        .HasColumnName("ModifiedTime");

                    b.Property<int>("SpId")
                        .HasColumnType("int")
                        .HasColumnName("SpId");

                    b.HasKey("Id")
                        .HasName("pk_BranchSupplier_id");

                    b.HasIndex("BId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("SpId");

                    b.ToTable("BranchSupplier");
                });

            modelBuilder.Entity("RCMServerData.Models.FirmType", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("pk_FirmType_id");

                    b.ToTable("FirmType");
                });

            modelBuilder.Entity("RCMServerData.Models.Product", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("Id"));

                    b.Property<short>("CatId")
                        .HasColumnType("smallint")
                        .HasColumnName("CatId");

                    b.Property<short?>("ColorCode")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<short?>("MenuListId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.Property<decimal?>("Price")
                        .HasPrecision(19, 4)
                        .HasColumnType("numeric(19,4)")
                        .HasColumnName("Price");

                    b.Property<decimal?>("VATpercent")
                        .HasColumnType("decimal")
                        .HasColumnName("VATpercent");

                    b.HasKey("Id")
                        .HasName("pk_Product_id");

                    b.HasIndex("CatId");

                    b.HasIndex("MenuListId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("RCMServerData.Models.ProductCategory", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.Property<short?>("TopCatId")
                        .HasColumnType("smallint");

                    b.HasKey("Id")
                        .HasName("pk_ProductCategory_id");

                    b.HasIndex("TopCatId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("RCMServerData.Models.ProductMenuList", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ListName")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_ProductMenuList_id");

                    b.ToTable("ProductMenuList");
                });

            modelBuilder.Entity("RCMServerData.Models.ProductSaleNote", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("Id"));

                    b.Property<string>("Definition")
                        .HasColumnType("text");

                    b.Property<short?>("NoteCat")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("NoteCat");

                    b.ToTable("ProductSaleNote");
                });

            modelBuilder.Entity("RCMServerData.Models.ProductSaleNoteCategory", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("Id"));

                    b.Property<string>("NotCat")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductSaleNoteCategory");
                });

            modelBuilder.Entity("RCMServerData.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<short>("BId")
                        .HasColumnType("smallint");

                    b.Property<int?>("DailyBillOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DailyBillOrder");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("DailyBillOrder"));

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("DateTime")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("timestamp")
                        .HasColumnName("DeletedTime");

                    b.Property<DateTime?>("EOD")
                        .HasColumnType("Date")
                        .HasColumnName("EOD");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEOD")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp")
                        .HasColumnName("ModifiedTime");

                    b.Property<short?>("STId")
                        .HasColumnType("smallint");

                    b.Property<string>("SaleNote")
                        .HasColumnType("text");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("UId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BId");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("STId");

                    b.HasIndex("UId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("RCMServerData.Models.SaleDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("UUID_GENERATE_V4()");

                    b.Property<short?>("BillOrder")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<short>("PId")
                        .HasColumnType("smallint");

                    b.Property<decimal>("Portion")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<short>("Qty")
                        .HasColumnType("smallint");

                    b.Property<int>("SId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.Property<string>("firstProductNote")
                        .HasColumnType("text");

                    b.Property<string>("generalProductNote")
                        .HasColumnType("text");

                    b.Property<string>("secondProductNote")
                        .HasColumnType("text");

                    b.Property<string>("thirdProductNote")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("PId");

                    b.HasIndex("SId");

                    b.ToTable("SaleDetail");
                });

            modelBuilder.Entity("RCMServerData.Models.SaleType", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("Id"));

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<short?>("TopSTId")
                        .HasColumnType("smallint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.HasIndex("TopSTId");

                    b.ToTable("SaleType");
                });

            modelBuilder.Entity("RCMServerData.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("Adress");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("CompanyName");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("CreatedTime")
                        .HasDefaultValueSql("current_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("date")
                        .HasColumnName("ModifiedTime");

                    b.HasKey("Id")
                        .HasName("pk_Supplier_id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("RCMServerData.Models.SupplierFirmType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("CreatedTime")
                        .HasDefaultValueSql("current_date");

                    b.Property<short>("FtId")
                        .HasColumnType("smallint")
                        .HasColumnName("FtId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("date")
                        .HasColumnName("ModifiedTime");

                    b.Property<int>("SpId")
                        .HasColumnType("int")
                        .HasColumnName("SpId");

                    b.HasKey("Id")
                        .HasName("pk_SupplierFirmType_id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("FtId");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("SpId");

                    b.ToTable("SupplierFirmType");
                });

            modelBuilder.Entity("RCMServerData.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("CreatedTime")
                        .HasDefaultValueSql("current_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar")
                        .HasColumnName("LastName");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("date")
                        .HasColumnName("ModifiedTime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .HasColumnName("Phone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("UserName");

                    b.HasKey("Id")
                        .HasName("pk_User_id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RCMServerData.Models.UserBranchAuthority", b =>
                {
                    b.Property<int>("UId")
                        .HasColumnType("int")
                        .HasColumnName("UId");

                    b.Property<short>("BId")
                        .HasColumnType("smallint")
                        .HasColumnName("BId");

                    b.Property<short>("ATId")
                        .HasColumnType("smallint")
                        .HasColumnName("ATId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.HasKey("UId", "BId", "ATId");

                    b.HasIndex("ATId");

                    b.HasIndex("BId");

                    b.ToTable("UserBranchAuthority");
                });

            modelBuilder.Entity("RCMServerData.Models.BranchProductPrice", b =>
                {
                    b.HasOne("RCMServerData.Models.Branch", "Branch")
                        .WithMany("BranchProductPrices")
                        .HasForeignKey("BId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCMServerData.Models.Product", "Product")
                        .WithMany("BranchProductPrices")
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RCMServerData.Models.BranchSupplier", b =>
                {
                    b.HasOne("RCMServerData.Models.Branch", "Branch")
                        .WithMany("BranchSuppliers")
                        .HasForeignKey("BId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BranchSupplier_Branch_BId");

                    b.HasOne("RCMServerData.Models.User", "UserCB")
                        .WithMany("BranchSuppliersCB")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BranchSupplier_User_CreatedBy");

                    b.HasOne("RCMServerData.Models.User", "UserMB")
                        .WithMany("BranchSuppliersMB")
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BranchSupplier_User_ModifiedBy");

                    b.HasOne("RCMServerData.Models.Supplier", "Supplier")
                        .WithMany("BranchSuppliers")
                        .HasForeignKey("SpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BranchSupplier_Supplier_SpId");

                    b.Navigation("Branch");

                    b.Navigation("Supplier");

                    b.Navigation("UserCB");

                    b.Navigation("UserMB");
                });

            modelBuilder.Entity("RCMServerData.Models.Product", b =>
                {
                    b.HasOne("RCMServerData.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_ProductCategory_CatId");

                    b.HasOne("RCMServerData.Models.ProductMenuList", "ProductMenuList")
                        .WithMany("Products")
                        .HasForeignKey("MenuListId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ProductCategory");

                    b.Navigation("ProductMenuList");
                });

            modelBuilder.Entity("RCMServerData.Models.ProductCategory", b =>
                {
                    b.HasOne("RCMServerData.Models.ProductCategory", "TopProductCategory")
                        .WithMany("SubProductCategories")
                        .HasForeignKey("TopCatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_SubProductCategories_TopProduct_TopCatId");

                    b.Navigation("TopProductCategory");
                });

            modelBuilder.Entity("RCMServerData.Models.ProductSaleNote", b =>
                {
                    b.HasOne("RCMServerData.Models.ProductSaleNoteCategory", "ProductSaleNoteCategory")
                        .WithMany("ProductSaleNotes")
                        .HasForeignKey("NoteCat")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ProductSaleNoteCategory");
                });

            modelBuilder.Entity("RCMServerData.Models.Sale", b =>
                {
                    b.HasOne("RCMServerData.Models.Branch", "Branch")
                        .WithMany("Sales")
                        .HasForeignKey("BId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCMServerData.Models.User", "UserDB")
                        .WithMany("SalesDB")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Sale_User_DeletedBy");

                    b.HasOne("RCMServerData.Models.User", "UserMB")
                        .WithMany("SalesMB")
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Sale_User_ModifiedBy");

                    b.HasOne("RCMServerData.Models.SaleType", "SaleType")
                        .WithMany("Sales")
                        .HasForeignKey("STId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RCMServerData.Models.User", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Sale_User_UId");

                    b.Navigation("Branch");

                    b.Navigation("SaleType");

                    b.Navigation("User");

                    b.Navigation("UserDB");

                    b.Navigation("UserMB");
                });

            modelBuilder.Entity("RCMServerData.Models.SaleDetail", b =>
                {
                    b.HasOne("RCMServerData.Models.User", "UserMB")
                        .WithMany("SaleDetailsMB")
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RCMServerData.Models.Product", "Product")
                        .WithMany("SaleDetails")
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCMServerData.Models.Sale", "Sale")
                        .WithMany("SaleDetails")
                        .HasForeignKey("SId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");

                    b.Navigation("UserMB");
                });

            modelBuilder.Entity("RCMServerData.Models.SaleType", b =>
                {
                    b.HasOne("RCMServerData.Models.SaleType", "TopSaleType")
                        .WithMany("SubSaleTypes")
                        .HasForeignKey("TopSTId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_SubSubSaleTypes_TopSaleType_TopSTId");

                    b.Navigation("TopSaleType");
                });

            modelBuilder.Entity("RCMServerData.Models.Supplier", b =>
                {
                    b.HasOne("RCMServerData.Models.User", "UserCB")
                        .WithMany("SuppliersCB")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Supplier_User_CreatedBy");

                    b.HasOne("RCMServerData.Models.User", "UserMB")
                        .WithMany("SuppliersMB")
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Supplier_User_ModifiedBy");

                    b.Navigation("UserCB");

                    b.Navigation("UserMB");
                });

            modelBuilder.Entity("RCMServerData.Models.SupplierFirmType", b =>
                {
                    b.HasOne("RCMServerData.Models.User", "UserCB")
                        .WithMany("SupplierFirmTypesCB")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SupplierFirmType_User_CreatedBy");

                    b.HasOne("RCMServerData.Models.FirmType", "FirmType")
                        .WithMany("SupplierFirmTypes")
                        .HasForeignKey("FtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SupplierFirmType_FirmType_FtId");

                    b.HasOne("RCMServerData.Models.User", "UserMB")
                        .WithMany("SupplierFirmTypesMB")
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SupplierFirmType_User_ModifiedBy");

                    b.HasOne("RCMServerData.Models.Supplier", "Supplier")
                        .WithMany("SupplierFirmTypes")
                        .HasForeignKey("SpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SupplierFirmType_Supplier_SpId");

                    b.Navigation("FirmType");

                    b.Navigation("Supplier");

                    b.Navigation("UserCB");

                    b.Navigation("UserMB");
                });

            modelBuilder.Entity("RCMServerData.Models.UserBranchAuthority", b =>
                {
                    b.HasOne("RCMServerData.Models.AuthorityType", "AuthorityType")
                        .WithMany("UserBranchAuthorities")
                        .HasForeignKey("ATId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserBranchAuthoritiy_AuthorityType_ATId");

                    b.HasOne("RCMServerData.Models.Branch", "Branch")
                        .WithMany("UserBranchAuthorities")
                        .HasForeignKey("BId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserBranchAuthoritiy_Branch_BId");

                    b.HasOne("RCMServerData.Models.User", "User")
                        .WithMany("UserBranchAuthorities")
                        .HasForeignKey("UId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserBranchAuthoritiy_User_UId");

                    b.Navigation("AuthorityType");

                    b.Navigation("Branch");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RCMServerData.Models.AuthorityType", b =>
                {
                    b.Navigation("UserBranchAuthorities");
                });

            modelBuilder.Entity("RCMServerData.Models.Branch", b =>
                {
                    b.Navigation("BranchProductPrices");

                    b.Navigation("BranchSuppliers");

                    b.Navigation("Sales");

                    b.Navigation("UserBranchAuthorities");
                });

            modelBuilder.Entity("RCMServerData.Models.FirmType", b =>
                {
                    b.Navigation("SupplierFirmTypes");
                });

            modelBuilder.Entity("RCMServerData.Models.Product", b =>
                {
                    b.Navigation("BranchProductPrices");

                    b.Navigation("SaleDetails");
                });

            modelBuilder.Entity("RCMServerData.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubProductCategories");
                });

            modelBuilder.Entity("RCMServerData.Models.ProductMenuList", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("RCMServerData.Models.ProductSaleNoteCategory", b =>
                {
                    b.Navigation("ProductSaleNotes");
                });

            modelBuilder.Entity("RCMServerData.Models.Sale", b =>
                {
                    b.Navigation("SaleDetails");
                });

            modelBuilder.Entity("RCMServerData.Models.SaleType", b =>
                {
                    b.Navigation("Sales");

                    b.Navigation("SubSaleTypes");
                });

            modelBuilder.Entity("RCMServerData.Models.Supplier", b =>
                {
                    b.Navigation("BranchSuppliers");

                    b.Navigation("SupplierFirmTypes");
                });

            modelBuilder.Entity("RCMServerData.Models.User", b =>
                {
                    b.Navigation("BranchSuppliersCB");

                    b.Navigation("BranchSuppliersMB");

                    b.Navigation("SaleDetailsMB");

                    b.Navigation("Sales");

                    b.Navigation("SalesDB");

                    b.Navigation("SalesMB");

                    b.Navigation("SupplierFirmTypesCB");

                    b.Navigation("SupplierFirmTypesMB");

                    b.Navigation("SuppliersCB");

                    b.Navigation("SuppliersMB");

                    b.Navigation("UserBranchAuthorities");
                });
#pragma warning restore 612, 618
        }
    }
}
