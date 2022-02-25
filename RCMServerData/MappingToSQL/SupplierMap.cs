using Microsoft.EntityFrameworkCore;
using RCMServerData.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCMServerData.MappingToSQL
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.SpId);

            builder.Property(x => x.SpId)
                .HasColumnName("SpId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.BId)
                .HasColumnName("BId")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.FTId)
                .HasColumnName("FTId")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(x => x.CurrentDept)
                .HasColumnName("CurrentDept")
                .HasColumnType("decimal")
                .HasPrecision(19, 4);

            builder.Property(x => x.Adress)
                .HasColumnName("Adress")
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(x => x.Phone)
                .HasColumnName("Phone")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(x => x.Note)
                .HasColumnName("Note")
                .HasColumnType("varchar")
                .HasMaxLength(200);

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
        }
    }
}
