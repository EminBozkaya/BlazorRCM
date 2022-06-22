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
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x => x.Id);
            //.HasName("pk_Sale_id");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.DateTime)
               .HasColumnName("DateTime")
               .HasColumnType("timestamp")
               .HasDefaultValueSql("NOW()")
               .IsRequired();

            builder.Property(x => x.EOD)
               .HasColumnName("EOD")
               .HasColumnType("Date");




            builder
                .HasOne(e => e.Branch)
                .WithMany(e => e.Sales)
                .HasForeignKey(f => f.BId)
                //.HasConstraintName("FK_Product_ProductCategory_CatId")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.Sales)
                .HasForeignKey(f => f.UId)
                //.HasConstraintName("FK_Product_ProductCategory_CatId")
                .OnDelete(DeleteBehavior.Cascade);



            //builder.Property(x => x.BId)
            //    .HasColumnName("BId")
            //    .HasColumnType("smallint")
            //    .IsRequired();

            //builder.Property(x => x.UId)
            //    .HasColumnName("UId")
            //    .HasColumnType("int")
            //    .IsRequired();

            //builder.Property(x => x.STId)
            //    .HasColumnName("STId")
            //    .HasColumnType("smallint")
            //    .IsRequired();



            //builder.Property(x => x.CTId)
            //    .HasColumnName("CTId")
            //    .HasColumnType("smallint")
            //    .IsRequired();



            //builder.Property(x => x.CId)
            //    .HasColumnName("CId")
            //    .HasColumnType("int");

            //builder.Property(x => x.SaleNote)
            //    .HasColumnName("SaleNote")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(100);

            //builder.Property(x => x.IpAdress)
            //    .HasColumnName("IpAdress")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(15)
            //    .IsUnicode(false)
            //    .IsRequired();

            //builder.Property(x => x.IsEOD)
            //    .HasColumnName("IsEOD")
            //    .HasColumnType("boolean")
            //    .IsRequired();

            //builder.Property(x => x.EOD)
            //    .HasColumnName("EOD")
            //    .HasColumnType("timestamp");

            //builder.Property(x => x.IsActive)
            //    .HasColumnName("IsActive")
            //    .HasColumnType("boolean")
            //    .IsRequired();






        }
    }
}
