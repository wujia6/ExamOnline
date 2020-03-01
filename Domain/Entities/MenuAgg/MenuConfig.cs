using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.MenuAgg
{
    public class MenuConfig : IEntityTypeConfiguration<MenuInfo>
    {
        public void Configure(EntityTypeBuilder<MenuInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Remarks).HasMaxLength(50);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(20);
            builder.Property(e => e.PathUrl).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Enabled);
            //builder.Property(e => e.ParentId).IsRequired();
            //builder.Property(e => e.MenuType).IsRequired();
            //builder.Property(e => e.Controller).IsRequired().HasMaxLength(20);
            //builder.Property(e => e.Action).IsRequired().HasMaxLength(20);
        }
    }
}
