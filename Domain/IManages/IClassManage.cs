using System.Linq;
using Domain.Entities.ClassAgg;
using Domain.IComm;

namespace Domain.IManages
{
    public interface IClassManage
    {
        #region ###ClassInfo接口
        bool InsertOrUpdate(ClassInfo inf);

        bool Remove(ISpecification<ClassInfo> spec);

        ClassInfo FindBySpec(ISpecification<ClassInfo> spec);

        IQueryable<ClassInfo> QueryBySpec(ISpecification<ClassInfo> spec);
        #endregion

        #region ###ClassExam接口
        bool Insert(ClassExam inf);

        bool Remove(ISpecification<ClassExam> spec);

        IQueryable<ClassExam> QueryBySpec(ISpecification<ClassExam> spec);
        #endregion

        #region ###ClassTeacher接口
        bool Insert(ClassTeacher inf);

        bool Remove(ISpecification<ClassTeacher> spec);

        IQueryable<ClassTeacher> QueryBySpec(ISpecification<ClassTeacher> spec);
        #endregion
    }
}
