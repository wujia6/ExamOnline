using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.RoleAgg
{
    public class RoleConfig : IEntityTypeConfiguration<RoleInfo>
    {
        public void Configure(EntityTypeBuilder<RoleInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(20);
        }
    }

    public class RoleMenuConfig : IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasOne(e => e.RoleInfomation).WithMany(s => s.RoleMenus);
            builder.HasOne(e => e.MenuInfomation).WithMany(s => s.RoleMenus);
        }
    }
}
