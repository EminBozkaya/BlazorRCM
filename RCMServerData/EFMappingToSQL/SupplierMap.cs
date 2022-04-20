using Microsoft.EntityFrameworkCore;
using RCMServerData.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCMServerData.EFMappingToSQL
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_Supplier_id");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Adress)
                .HasColumnName("Adress")
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasColumnType("int");

            builder.Property(x => x.CreatedTime)
                .HasColumnName("CreatedTime")
                .HasColumnType("date")
                .HasDefaultValueSql("current_date");

            builder.Property(x => x.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasColumnType("int");

            builder.Property(x => x.ModifiedTime)
                .HasColumnName("ModifiedTime")
                .HasColumnType("date");

            builder.Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("boolean")
                .IsRequired();




            builder
                .HasOne(e => e.UserCB)
                .WithMany(e => e.SuppliersCB)
                .HasForeignKey(f => f.CreatedBy)
                .HasConstraintName("FK_Supplier_User_CreatedBy")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.UserMB)
                .WithMany(e => e.SuppliersMB)
                .HasForeignKey(f => f.ModifiedBy)
                .HasConstraintName("FK_Supplier_User_ModifiedBy")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
