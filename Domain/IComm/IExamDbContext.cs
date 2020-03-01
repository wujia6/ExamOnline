using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Domain.Entities.UserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.AnwserAgg;
using Domain.Entities.MenuAgg;
using Domain.Entities.RoleAgg;
using Domain.Entities.PermissionAgg;

namespace Domain.IComm
{
    public interface IExamDbContext: IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entry) where T : class;

        DbSet<PermissionInfo> Permissions { get; set; }
        DbSet<MenuInfo> Menus { get; set; }
        DbSet<RoleInfo> Roles { get; set; }
        DbSet<RoleAuthorize> RoleAuthorizes { get; set; }
        DbSet<RoleMenu> RoleMenus { get; set; }
        DbSet<UserInfo> Users{ get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<AdminInfo> Admins { get; set; }
        DbSet<TeacherInfo> Teachers { get; set; }
        DbSet<StudentInfo> Students { get; set; }
        DbSet<ClassInfo> Classes { get; set; }
        DbSet<ClassExamination> ClassExaminations { get; set; }
        DbSet<ClassTeacher> ClassTeachers { get; set; }
        DbSet<QuestionInfo> Questions { get; set; }
        DbSet<ExaminationInfo> Examinations { get; set; }
        DbSet<AnswerInfo> Answers { get; set; }
    }
}
