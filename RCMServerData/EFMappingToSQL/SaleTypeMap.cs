using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCMServerData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMServerData.EFMappingToSQL
{
    public class SaleTypeMap : IEntityTypeConfiguration<SaleType>
    {
        public void Configure(EntityTypeBuilder<SaleType> builder)
        {
            builder.HasKey(x => x.Id);
            //.HasName("pk_SaleType_id");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("smallint")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Type)
                .HasColumnName("Type")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(e => e.SubSaleTypes)
                .WithOne(f => f.TopSaleType)
                .HasForeignKey(g => g.TopSTId)
                .HasConstraintName("FK_SubSubSaleTypes_TopSaleType_TopSTId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
