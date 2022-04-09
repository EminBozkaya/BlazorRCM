using Microsoft.EntityFrameworkCore;
using RCMServerData.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCMServerData.EFMappingToSQL
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




            builder
                .HasOne(e => e.User)
                .WithMany(e => e.UserBranchAuthorities)
                .HasForeignKey(f => f.UId)
                .HasConstraintName("FK_UserBranchAuthoritiy_User_UId");
            //.OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.Branch)
                .WithMany(e => e.UserBranchAuthorities)
                .HasForeignKey(f => f.BId)
                .HasConstraintName("FK_UserBranchAuthoritiy_Branch_BId");
            //.OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.AuthorityType)
                .WithMany(e => e.UserBranchAuthorities)
                .HasForeignKey(f => f.ATId)
                .HasConstraintName("FK_UserBranchAuthoritiy_AuthorityType_ATId");
            //.OnDelete(DeleteBehavior.Cascade);

            //builder.HasKey(uba => new { uba.UId, uba.BId, uba.ATId });



        }
    }
}
