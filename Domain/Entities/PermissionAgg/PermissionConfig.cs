using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.PermissionAgg
{
    public class PermissionConfig : IEntityTypeConfiguration<PermissionInfo>
    {
        public void Configure(EntityTypeBuilder<PermissionInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Remarks).HasMaxLength(50);
            builder.Property(e => e.LevelID).IsRequired();
            builder.Property(e => e.TypeAt).IsRequired();
            builder.Property(e => e.Named).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Command).IsRequired().HasMaxLength(20);
        }
    }
}
