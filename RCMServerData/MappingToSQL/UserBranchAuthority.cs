using Microsoft.EntityFrameworkCore;
using RCMServerData.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCMServerData.MappingToSQL
{
    public class UserBranchAuthorityMap : IEntityTypeConfiguration<UserBranchAuthority>
    {
        public void Configure(EntityTypeBuilder<UserBranchAuthority> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_UserBranchAuthority_id");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.UId)
                .HasColumnName("UId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.BId)
                .HasColumnName("BId")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(x => x.ATId)
                .HasColumnName("ATId")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("boolean")
                .IsRequired();
        }
    }
}
