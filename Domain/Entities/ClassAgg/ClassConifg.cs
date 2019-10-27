using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.ClassAgg
{
    public class ClassConifg : IEntityTypeConfiguration<ClassInfo>
    {
        public void Configure(EntityTypeBuilder<ClassInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Grade).IsRequired();
            builder.Property(e => e.Category).IsRequired();
            builder.Property(e => e.CreateDate).IsRequired();
            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.Remarks).IsRequired().HasMaxLength(50);
        }
    }

    public class ClassTeacherConfig : IEntityTypeConfiguration<ClassTeacher>
    {
        public void Configure(EntityTypeBuilder<ClassTeacher> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasOne(s => s.ClassInfomation).WithMany(m => m.ClassTeachers);
            builder.HasOne(s => s.TeacherInfomation).WithMany(m => m.ClassTeachers);
        }
    }

    public class ClassExaminationConfig : IEntityTypeConfiguration<ClassExamination>
    {
        public void Configure(EntityTypeBuilder<ClassExamination> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasOne(s => s.ClassInfomation).WithMany(m => m.ClassExams);
            builder.HasOne(s => s.ExamInfomation).WithMany(m => m.ClassExams);
        }
    }
}
