using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore;

namespace Domain.Profile
{
    public class SqlContext : DbContext, ISqlContext
    {
        public SqlContext(DbContextOptions<SqlContext> options): base(options)
        {
            //构造方法
        }

        //实体模型创建
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new ClassConifg());
            modelBuilder.ApplyConfiguration(new ClassTeacherConfig());
            modelBuilder.ApplyConfiguration(new ClassExamConfig());
            modelBuilder.ApplyConfiguration(new QuestionInfoConfig());
            modelBuilder.ApplyConfiguration(new ExamInfoConfig());
            modelBuilder.ApplyConfiguration(new AnswerInfoConfig());
            base.OnModelCreating(modelBuilder);
        }

        #region ###实现ISqlContext接口
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassInfo> ClassInfos { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
        public DbSet<ClassExam> ClassExams { get; set; }
        public DbSet<QuestionInfo> QuestionInfos { get; set; }
        public DbSet<ExamInfo> ExamInfos { get; set; }
        public DbSet<AnswerInfo> AnswerInfos { get; set; }
        #endregion
    }
}
