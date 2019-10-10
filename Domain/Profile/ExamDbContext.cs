using System.Threading.Tasks;
using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.Profile
{
    public class ExamDbContext: DbContext, IExamDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ExamDbStr"));
            base.OnConfiguring(optionsBuilder);
        }

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

        public async Task<int> SaveChangesAsync()
        {
            return await this.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            this.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            this.Database.RollbackTransaction();
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
