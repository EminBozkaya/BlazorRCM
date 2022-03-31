using Microsoft.EntityFrameworkCore;
using RCMServerData.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCMServerData.EFMappingToSQL
{
    public class SupplierFirmTypeMap : IEntityTypeConfiguration<SupplierFirmType>
    {
        public void Configure(EntityTypeBuilder<SupplierFirmType> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_SupplierFirmType_id");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.SpId)
                .HasColumnName("SpId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.FtId)
                .HasColumnName("FtId")
                .HasColumnType("smallint")
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
                .HasOne(e => e.Supplier)
                .WithMany(e => e.SupplierFirmTypes)
                .HasForeignKey(f=>f.SpId)
                .HasConstraintName("FK_SupplierFirmType_Supplier_SpId")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.FirmType)
                .WithMany(e => e.SupplierFirmTypes)
                .HasForeignKey(f => f.FtId)
                .HasConstraintName("FK_SupplierFirmType_FirmType_FtId")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.SupplierFirmTypes)
                .HasForeignKey(f => f.CreatedBy)
                .HasConstraintName("FK_SupplierFirmType_User_CreatedBy")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.SupplierFirmTypes)
                .HasForeignKey(f => f.ModifiedBy)
                .HasConstraintName("FK_SupplierFirmType_User_ModifiedBy")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
