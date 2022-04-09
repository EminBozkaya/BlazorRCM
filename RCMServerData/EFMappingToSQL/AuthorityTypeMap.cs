using Microsoft.EntityFrameworkCore;
using RCMServerData.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCMServerData.EFMappingToSQL
{
    public class AuthorityTypeMap : IEntityTypeConfiguration<AuthorityType>
    {
       
        public void Configure(EntityTypeBuilder<AuthorityType> builder)
        {

            builder.HasKey(x => x.Id)
                .HasName("pk_AuthorityType_id");


            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("smallint")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();


            builder.Property(x => x.Type)
                .HasColumnName("Type")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            
        }
    }
}
