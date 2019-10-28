using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.UserAgg
{
    public class UserConfig : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Account).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Pwd).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Gender).IsRequired();
            builder.Property(e => e.Tel).IsRequired().HasMaxLength(11);
            builder.Property(e => e.CreateDate).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(50);
        }
    }

    public class AdminConfig : IEntityTypeConfiguration<AdminInfo>
    {
        public void Configure(EntityTypeBuilder<AdminInfo> builder)
        { }
    }

    public class TeacherConfig : IEntityTypeConfiguration<TeacherInfo>
    {
        public void Configure(EntityTypeBuilder<TeacherInfo> builder)
        {
            builder.Property(e => e.Profssion).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Course).IsRequired();
        }
    }

    public class StudentConfig : IEntityTypeConfiguration<StudentInfo>
    {
        public void Configure(EntityTypeBuilder<StudentInfo> builder)
        {
            builder.Property(e => e.StudentNo).IsRequired().HasMaxLength(20);
            builder.Property(e => e.IdentityNo).IsRequired().HasMaxLength(18);
            builder.Property(e => e.ParentTel).IsRequired().HasMaxLength(15);
            builder.Property(e => e.District).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Dormitory).IsRequired().HasMaxLength(20);
            //关系一对多
            builder.HasOne(s => s.ClassInfomation).WithMany(m => m.StudentInfomations);
        }
    }

    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasOne(e => e.UserInfomation).WithMany(s => s.UserRoles);
            builder.HasOne(e => e.RoleInfomation).WithMany(s => s.UserRoles);
        }
    }
}
