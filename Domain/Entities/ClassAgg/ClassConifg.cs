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
            builder.HasOne(s => s.ClassInfo).WithMany(m => m.ClassTeachers);
            builder.HasOne(s => s.TeacherInfo).WithMany(m => m.ClassTeachers);
        }
    }

    public class ClassExamConfig : IEntityTypeConfiguration<ClassExam>
    {
        public void Configure(EntityTypeBuilder<ClassExam> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasOne(s => s.ClassInfo).WithMany(m => m.ClassExams);
            builder.HasOne(s => s.ExamInfo).WithMany(m => m.ClassExams);
        }
    }
}
