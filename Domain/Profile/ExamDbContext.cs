using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.MenuAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.RoleAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.Profile
{
    public class ExamDbContext: DbContext, IExamDbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .Build();
        //    optionsBuilder.UseSqlServer(config.GetConnectionString("ExamDbConnection"));
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder model)
        {
            //menus
            model.ApplyConfiguration(new MenuConfig());
            //roles
            model.ApplyConfiguration(new RoleConfig());
            model.ApplyConfiguration(new RoleMenuConfig());
            //users
            model.ApplyConfiguration(new UserConfig())
                .Entity<UserInfo>()
                .HasDiscriminator<string>("UserType")
                .HasValue<AdminInfo>("admin")
                .HasValue<TeacherInfo>("teacher")
                .HasValue<StudentInfo>("student");
            model.ApplyConfiguration(new UserRoleConfig());
            model.ApplyConfiguration(new AdminConfig());
            model.ApplyConfiguration(new TeacherConfig());
            model.ApplyConfiguration(new StudentConfig());
            //classes
            model.ApplyConfiguration(new ClassConifg());
            model.ApplyConfiguration(new ClassTeacherConfig());
            model.ApplyConfiguration(new ClassExaminationConfig());
            //questions
            model.ApplyConfiguration(new QuestionInfoConfig());
            //exams
            model.ApplyConfiguration(new ExaminationConfig());
            //answers
            model.ApplyConfiguration(new AnswerInfoConfig());
            base.OnModelCreating(model);
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
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<AdminInfo> Admins { get; set; }
        public DbSet<TeacherInfo> Teachers { get; set; }
        public DbSet<StudentInfo> Students { get; set; }
        public DbSet<ClassInfo> Classes { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
        public DbSet<ClassExamination> ClassExaminations { get; set; }
        public DbSet<QuestionInfo> Questions { get; set; }
        public DbSet<ExaminationInfo> Examinations { get; set; }
        public DbSet<AnswerInfo> Answers { get; set; }
        #endregion
    }
}
