using System.Threading.Tasks;
using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.MenuAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.RoleAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.Profile
{
    public class ExamDbContext: DbContext, IExamDbContext
    {
        //public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("SQLLocalDB"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new RoleMenuConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
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

        #region ###实现IExamDbContext接口
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

        public DbSet<MenuInfo> Menus { get; set; }
        public DbSet<RoleInfo> Roles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<AdminInfo> Admins { get; set; }
        public DbSet<TeacherInfo> Teachers { get; set; }
        public DbSet<StudentInfo> Students { get; set; }
        public DbSet<ClassInfo> ClassInfos { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
        public DbSet<ClassExam> ClassExams { get; set; }
        public DbSet<QuestionInfo> QuestionInfos { get; set; }
        public DbSet<ExamInfo> ExamInfos { get; set; }
        public DbSet<AnswerInfo> AnswerInfos { get; set; }
        #endregion
    }
}
