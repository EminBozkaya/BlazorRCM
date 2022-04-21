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
    public class SaleDetailMap : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.HasKey(x => x.Id);
                //.HasName("pk_SaleDetail_id");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("uuid")
                .HasDefaultValueSql("UUID_GENERATE_V4()")
                .IsRequired();

            



            builder
                .HasOne(e => e.Sale)
                .WithMany(e => e.SaleDetails)
                .HasForeignKey(f => f.SId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.Product)
                .WithMany(e => e.SaleDetails)
                .HasForeignKey(f => f.PId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.UserMB)
                .WithMany(e => e.SaleDetailsMB)
                .HasForeignKey(f => f.ModifiedBy)
                .OnDelete(DeleteBehavior.Cascade);





            //builder.Property(x => x.SId)
            //    .HasColumnName("SId")
            //    .HasColumnType("int")
            //    .IsRequired();

            //builder.Property(x => x.PId)
            //    .HasColumnName("PId")
            //    .HasColumnType("smallint")
            //    .IsRequired();

            //builder.Property(x => x.ModifiedBy)
            //        .HasColumnName("ModifiedBy")
            //        .HasColumnType("int");


            //builder.Property(x => x.Price)
            //        .HasColumnName("Price")
            //        .HasColumnType("decimal")
            //        .HasPrecision(10, 4)
            //        .IsRequired();

            //builder.Property(x => x.Qty)
            //        .HasColumnName("Qty")
            //        .HasColumnType("smallint")
            //        .IsRequired();

            //builder.Property(x => x.Portion)
            //        .HasColumnName("Portion")
            //        .HasColumnType("decimal")
            //        .IsRequired();

            //builder.Property(x => x.Total)
            //        .HasColumnName("Total")
            //        .HasColumnType("decimal")
            //        .HasPrecision(10, 4)
            //        .IsRequired();

            //builder.Property(x => x.Note)
            //        .HasColumnName("Note")
            //        .HasColumnType("nvarchar")
            //        .HasMaxLength(100);

            //builder.Property(x => x.CutOff)
            //        .HasColumnName("CutOff")
            //        .HasColumnType("decimal")
            //        .HasPrecision(10, 4);

            //builder.Property(x => x.IsActive)
            //        .HasColumnName("IsActive")
            //        .HasColumnType("boolean")
            //        .IsRequired();


            //builder.Property(x => x.ModifiedTime)
            //        .HasColumnName("ModifiedTime")
            //        .HasColumnType("timestamp");







            //----?????----------
            //builder
            //    .HasOne(e => e.Users)
            //    .WithMany()
            //    .HasForeignKey(f=>f.ModifiedBy);

            //builder
            //    .OwnsMany(x=>x.Products)
            //    .OwnsOne(p => p.SaleDetails);

        }
    }
}
