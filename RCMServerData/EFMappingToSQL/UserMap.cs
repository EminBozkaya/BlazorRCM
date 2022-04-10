using Microsoft.EntityFrameworkCore;
using RCMServerData.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCMServerData.EFMappingToSQL
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_User_id");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            //builder.Property(x => x.FullName)
            //    .HasColumnName("FullName")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(50)
            //    .IsRequired();

            builder.Property(x => x.Phone)
                .HasColumnName("Phone")
                .HasColumnType("char")
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .HasColumnType("varchar")
                .HasMaxLength(255)
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
