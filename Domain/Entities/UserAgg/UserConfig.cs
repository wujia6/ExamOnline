using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.UserAgg
{
    public class AdminConfig : IEntityTypeConfiguration<AdminInfo>
    {
        public void Configure(EntityTypeBuilder<AdminInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Account).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Pwd).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Gender).IsRequired();
            builder.Property(e => e.Age).IsRequired();
            builder.Property(e => e.Tel).IsRequired().HasMaxLength(15);
            builder.Property(e => e.CreateDate).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(50);
        }
    }

    public class TeacherConfig : IEntityTypeConfiguration<TeacherInfo>
    {
        public void Configure(EntityTypeBuilder<TeacherInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Account).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Pwd).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Gender).IsRequired();
            builder.Property(e => e.Age).IsRequired();
            builder.Property(e => e.Tel).IsRequired().HasMaxLength(15);
            builder.Property(e => e.Profssion).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Course).IsRequired();
            builder.Property(e => e.CreateDate).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(50);
        }
    }

    public class StudentConfig : IEntityTypeConfiguration<StudentInfo>
    {
        public void Configure(EntityTypeBuilder<StudentInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Account).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Pwd).IsRequired().HasMaxLength(50);
            builder.Property(e => e.StudentNo).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Gender).IsRequired();
            builder.Property(e => e.Age).IsRequired();
            builder.Property(e => e.IdentityNo).IsRequired().HasMaxLength(18);
            builder.Property(e => e.Tel).IsRequired().HasMaxLength(15);
            builder.Property(e => e.ParentTel).IsRequired().HasMaxLength(15);
            builder.Property(e => e.District).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Dormitory).IsRequired().HasMaxLength(20);
            builder.Property(e => e.CreateDate).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(50);
            //关系一对多
            builder.HasOne(s => s.ClassInfo).WithMany(m => m.StudentInfos);
        }
    }
}
