using Microsoft.EntityFrameworkCore;
using RCMServerData.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCMServerData.EFMappingToSQL
{
    public class BranchSupplierMap : IEntityTypeConfiguration<BranchSupplier>
    {
        public void Configure(EntityTypeBuilder<BranchSupplier> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_BranchSupplier_id");
            

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.BId)
                .HasColumnName("BId")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(x => x.SpId)
                .HasColumnName("SpId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.CreatedTime)
                .HasColumnName("CreatedTime")
                .HasColumnType("date")
                .HasDefaultValueSql("current_date");

            builder.Property(x => x.ModifiedTime)
                .HasColumnName("ModifiedTime")
                .HasColumnType("date");

            builder.Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("boolean")
                .IsRequired();




            builder
                .HasOne(e => e.Branch)
                .WithMany(e => e.BranchSuppliers)
                .HasForeignKey(f => f.BId)
                .HasConstraintName("FK_BranchSupplier_Branch_BId")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.Supplier)
                .WithMany(e => e.BranchSuppliers)
                .HasForeignKey(f => f.SpId)
                .HasConstraintName("FK_BranchSupplier_Supplier_SpId")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.BranchSuppliers)
                .HasForeignKey(f => f.CreatedBy)
                .HasConstraintName("FK_BranchSupplier_User_CreatedBy")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.BranchSuppliers)
                .HasForeignKey(f => f.ModifiedBy)
                .HasConstraintName("FK_BranchSupplier_User_ModifiedBy")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
