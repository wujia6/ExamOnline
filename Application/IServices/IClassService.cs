using System.Linq;
using Domain.Entities.ClassAgg;
using Domain.IComm;

namespace Application.IServices
{
    /// <summary>
    /// 班级应用服务接口
    /// </summary>
    public interface IClassService
    {
        #region ###ClassInfo接口
        bool InsertOrUpdate(ClassInfo inf);

        bool Remove(ISpecification<ClassInfo> spec);

        ClassInfo Single(ISpecification<ClassInfo> spec);

        IQueryable<ClassInfo> Query(ISpecification<ClassInfo> spec);
        #endregion

        #region ###ClassExam接口
        bool Insert(ClassExam inf);

        bool Remove(ISpecification<ClassExam> spec);

        IQueryable<ClassExam> Query(ISpecification<ClassExam> spec);
        #endregion

        #region ###ClassTeacher接口
        bool Insert(ClassTeacher inf);

        bool Remove(ISpecification<ClassTeacher> spec);

        IQueryable<ClassTeacher> Query(ISpecification<ClassTeacher> spec);
        #endregion
    }
}
