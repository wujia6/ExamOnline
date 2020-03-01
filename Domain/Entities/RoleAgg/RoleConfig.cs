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
            builder.Property(e => e.Remarks).HasMaxLength(50);
        }
    }

    public class RoleAuthorizeConfig : IEntityTypeConfiguration<RoleAuthorize>
    {
        public void Configure(EntityTypeBuilder<RoleAuthorize> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Remarks).HasMaxLength(50);
            builder.HasOne(e => e.RoleInformation).WithMany(s => s.RoleAuthorizes);
            builder.HasOne(e => e.PermissionInformation).WithMany(s => s.RoleAuthorizes);
        }
    }

    //public class RoleMenuConfig : IEntityTypeConfiguration<RoleMenu>
    //{
    //    public void Configure(EntityTypeBuilder<RoleMenu> builder)
    //    {
    //        builder.HasKey(e => e.ID);
    //        builder.Property(e => e.Remarks).HasMaxLength(50);
    //        builder.HasOne(e => e.RoleInfomation).WithMany(s => s.RoleMenus);
    //        builder.HasOne(e => e.MenuInfomation).WithMany(s => s.RoleMenus);
    //    }
    //}
}
