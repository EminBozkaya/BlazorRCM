using Microsoft.EntityFrameworkCore;
using RCMServerData.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCMServerData.EFMappingToSQL
{
    public class FirmTypeMap : IEntityTypeConfiguration<FirmType>
    {
        public void Configure(EntityTypeBuilder<FirmType> builder)
        {
            builder.HasKey(x => x.FTId)
                .HasName("pk_FirmType_id");

            builder.Property(x => x.FTId)
                .HasColumnName("FTId")
                .HasColumnType("smallint")
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(30);
        }
    }
}
