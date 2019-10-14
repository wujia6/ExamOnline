using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Domain.Entities.UserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.AnwserAgg;

namespace Domain.IComm
{
    public interface IExamDbContext: IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry Entry(object entry);

        DbSet<AdminInfo> Admins { get; set; }
        DbSet<TeacherInfo> Teachers { get; set; }
        DbSet<StudentInfo> Students { get; set; }
        DbSet<ClassInfo> ClassInfos { get; set; }
        DbSet<ClassExam> ClassExams { get; set; }
        DbSet<ClassTeacher> ClassTeachers { get; set; }
        DbSet<QuestionInfo> QuestionInfos { get; set; }
        DbSet<ExamInfo> ExamInfos { get; set; }
        DbSet<AnswerInfo> AnswerInfos { get; set; }
    }
}
