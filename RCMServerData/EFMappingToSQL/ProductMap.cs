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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_Product_id");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("smallint")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CatId)
                .HasColumnName("CatId")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal")
                .HasPrecision(19, 4);

            builder.Property(x => x.VATpercent)
                .HasColumnName("VATpercent")
                .HasColumnType("decimal");

            builder.Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("boolean")
                .IsRequired();







            builder
                .HasOne(e => e.ProductCategory)
                .WithMany(e => e.Products)
                .HasForeignKey(f => f.CatId)
                .HasConstraintName("FK_Product_ProductCategory_CatId")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.ProductMenuList)
                .WithMany(e => e.Products)
                .HasForeignKey(f => f.MenuListId)
                .OnDelete(DeleteBehavior.Cascade);


        }
                
    }
}
