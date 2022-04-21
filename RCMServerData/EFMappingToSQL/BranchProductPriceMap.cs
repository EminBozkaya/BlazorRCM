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
    public class BranchProductPriceMap : IEntityTypeConfiguration<BranchProductPrice>
    {

        public void Configure(EntityTypeBuilder<BranchProductPrice> builder)
        {

            //builder.HasKey(x => x.Id)
            //    .HasName("pk_BranchProductPrice_id");


            //builder.Property(x => x.Id)
            //    .HasColumnName("Id")
            //    .HasColumnType("int")
            //    .ValueGeneratedOnAdd()
            //    .UseIdentityAlwaysColumn();


            builder.HasKey(bpp => new { bpp.BId, bpp.PId});

            //builder.Property(x => x.BId)
            //    .HasColumnName("BId")
            //    .HasColumnType("smallint")
            //    .IsRequired();

            //builder.Property(x => x.PId)
            //    .HasColumnName("PId")
            //    .HasColumnType("smallint")
            //    .IsRequired();

            //builder.Property(x => x.BranchPrice)
            //    .HasColumnName("BranchPrice")
            //    .HasColumnType("decimal")
            //    .HasPrecision(10, 4)
            //    .IsRequired();

            //builder.Property(x => x.VATpercent)
            //    .HasColumnName("VATpercent")
            //    .HasColumnType("decimal")
            //    .HasPrecision(5, 2);

            //builder.Property(x => x.IsFavorite)
            //    .HasColumnName("IsFavorite")
            //    .HasColumnType("boolean");

            //builder.Property(x => x.IsActive)
            //    .HasColumnName("IsActive")
            //    .HasColumnType("boolean")
            //    .IsRequired();



            builder
                .HasOne(e => e.Branch)
                .WithMany(e => e.BranchProductPrices)
                .HasForeignKey(f => f.BId);
            //.HasConstraintName("FK_UserBranchAuthoritiy_User_UId");
            //.OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.Product)
                .WithMany(e => e.BranchProductPrices)
                .HasForeignKey(f => f.PId);
                //.HasConstraintName("FK_UserBranchAuthoritiy_Branch_BId");
            //.OnDelete(DeleteBehavior.Cascade);

        }
    }
}
