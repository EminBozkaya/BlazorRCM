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
    public class ProductMenuListMap : IEntityTypeConfiguration<ProductMenuList>
    {
        public void Configure(EntityTypeBuilder<ProductMenuList> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_ProductMenuList_id");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("smallint")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();



        }
                
    }
}
