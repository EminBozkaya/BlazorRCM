using Microsoft.EntityFrameworkCore;
using RCMServerData.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCMServerData.EFMappingToSQL
{
    public class BranchMap : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_Branch_id");

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

            builder.Property(x => x.Adress)
                .HasColumnName("Adress")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(x => x.CreatedTime)
                .HasColumnName("CreatedTime")
                .HasColumnType("date")
                .HasDefaultValueSql("current_date");

            builder.Property(x => x.ModifiedTime)
                .HasColumnName("ModifiedTime")
                .HasColumnType("date");
                


        }
    }
}
