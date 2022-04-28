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
    public class ProductSaleNoteCategoryMap : IEntityTypeConfiguration<ProductSaleNoteCategory>
    {
        public void Configure(EntityTypeBuilder<ProductSaleNoteCategory> builder)
        {
            builder.HasKey(x => x.Id);
                

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("smallint")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            
        }
    }
}
