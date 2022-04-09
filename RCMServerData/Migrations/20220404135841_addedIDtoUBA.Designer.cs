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
    [Migration("20220404135841_addedIDtoUBA")]
    partial class addedIDtoUBA
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
                    b.Property<short>("ATId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("ATId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("ATId"));

                    b.Property<string>("Type")
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("Type");

                    b.HasKey("ATId")
                        .HasName("pk_AuthorityType_id");

                    b.ToTable("AuthorityType");
                });

            modelBuilder.Entity("RCMServerData.Models.Branch", b =>
                {
                    b.Property<short>("BId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("BId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("BId"));

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

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("date")
                        .HasColumnName("ModifiedTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.HasKey("BId")
                        .HasName("pk_Branch_id");

                    b.ToTable("Branch");
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

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("date")
                        .HasColumnName("ModifiedTime");

                    b.Property<int>("SpId")
                        .HasColumnType("int")
                        .HasColumnName("SpId");

                    b.HasKey("Id")
                        .HasName("pk_BranchSupplier_id");

                    b.HasIndex("BId");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("SpId");

                    b.ToTable("BranchSupplier");
                });

            modelBuilder.Entity("RCMServerData.Models.FirmType", b =>
                {
                    b.Property<short>("FTId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("FTId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<short>("FTId"));

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.HasKey("FTId")
                        .HasName("pk_FirmType_id");

                    b.ToTable("FirmType");
                });

            modelBuilder.Entity("RCMServerData.Models.Supplier", b =>
                {
                    b.Property<int>("SpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SpId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("SpId"));

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

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("date")
                        .HasColumnName("ModifiedTime");

                    b.HasKey("SpId")
                        .HasName("pk_Supplier_id");

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

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("date")
                        .HasColumnName("ModifiedTime");

                    b.Property<int>("SpId")
                        .HasColumnType("int")
                        .HasColumnName("SpId");

                    b.HasKey("Id")
                        .HasName("pk_SupplierFirmType_id");

                    b.HasIndex("FtId");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("SpId");

                    b.ToTable("SupplierFirmType");
                });

            modelBuilder.Entity("RCMServerData.Models.User", b =>
                {
                    b.Property<int>("UId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("UId"));

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

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("date")
                        .HasColumnName("ModifiedTime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("char(12)")
                        .HasColumnName("Phone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("UserName");

                    b.HasKey("UId")
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

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.HasKey("UId", "BId", "ATId");

                    b.HasIndex("ATId");

                    b.HasIndex("BId");

                    b.ToTable("UserBranchAuthority");
                });

            modelBuilder.Entity("RCMServerData.Models.BranchSupplier", b =>
                {
                    b.HasOne("RCMServerData.Models.Branch", "Branch")
                        .WithMany("BranchSuppliers")
                        .HasForeignKey("BId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BranchSupplier_Branch_BId");

                    b.HasOne("RCMServerData.Models.User", "User")
                        .WithMany("BranchSuppliers")
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

                    b.Navigation("User");
                });

            modelBuilder.Entity("RCMServerData.Models.Supplier", b =>
                {
                    b.HasOne("RCMServerData.Models.User", "User")
                        .WithMany("Suppliers")
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Supplier_User_ModifiedBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RCMServerData.Models.SupplierFirmType", b =>
                {
                    b.HasOne("RCMServerData.Models.FirmType", "FirmType")
                        .WithMany("SupplierFirmTypes")
                        .HasForeignKey("FtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SupplierFirmType_FirmType_FtId");

                    b.HasOne("RCMServerData.Models.User", "User")
                        .WithMany("SupplierFirmTypes")
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

                    b.Navigation("User");
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
                    b.Navigation("BranchSuppliers");

                    b.Navigation("UserBranchAuthorities");
                });

            modelBuilder.Entity("RCMServerData.Models.FirmType", b =>
                {
                    b.Navigation("SupplierFirmTypes");
                });

            modelBuilder.Entity("RCMServerData.Models.Supplier", b =>
                {
                    b.Navigation("BranchSuppliers");

                    b.Navigation("SupplierFirmTypes");
                });

            modelBuilder.Entity("RCMServerData.Models.User", b =>
                {
                    b.Navigation("BranchSuppliers");

                    b.Navigation("SupplierFirmTypes");

                    b.Navigation("Suppliers");

                    b.Navigation("UserBranchAuthorities");
                });
#pragma warning restore 612, 618
        }
    }
}
