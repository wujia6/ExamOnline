using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Domain.Entities.UserAgg;
using Domain.Entities.ClassAgg;

namespace Domain.IComm
{
    public interface ISqlContext: IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry Entry(object entry);

        DbSet<Admin> Admins { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<ClassInfo> ClassInfos { get; set; }
        DbSet<ClassTeacher> ClassTeachers { get; set; }
    }
}
