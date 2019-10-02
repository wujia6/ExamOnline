using System.Linq;
using Domain.Entities.ClassAgg;
using Domain.IComm;
using Domain.IManages;
using Microsoft.EntityFrameworkCore;

namespace Domain.Manages
{
    internal class ClassManage: IClassManage
    {
        private readonly IEfCoreRepository<ClassInfo> efCore;

        public ClassManage(IEfCoreRepository<ClassInfo> ef)
        {
            this.efCore = ef;
        }

        #region ###ClassInfo接口
        public bool InsertOrUpdate(ClassInfo inf)
        {
            if (inf == null)
                return false;
            return inf.ID == null ? efCore.InsertEntity(inf) : efCore.UpdateEntity(inf);
        }

        public bool Remove(ISpecification<ClassInfo> spec)
        {
            var entity = FindBySpec(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }

        public ClassInfo FindBySpec(ISpecification<ClassInfo> spec)
        {
            return efCore.FindBySpec(spec);
        }

        public IQueryable<ClassInfo> QueryBySpec(ISpecification<ClassInfo> spec)
        {
            return efCore.QueryBySpec(spec);
        }
        #endregion

        #region ###ClassExam接口
        public bool Insert(ClassExam inf)
        {
            if (inf == null)
                return false;
            efCore.SqlContext.Entry(inf).State = EntityState.Added;
            return true;
        }

        public bool Remove(ISpecification<ClassExam> spec)
        {
            var entity = efCore.SqlContext.Set<ClassExam>().FirstOrDefault(spec.Expression);
            if (entity == null)
                return false;
            efCore.SqlContext.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        public IQueryable<ClassExam> QueryBySpec(ISpecification<ClassExam> spec)
        {
            return efCore.SqlContext.Set<ClassExam>().Where(spec.Expression);
        }
        #endregion

        #region ###ClassTeacher接口
        public bool Insert(ClassTeacher inf)
        {
            if (inf == null)
                return false;
            efCore.SqlContext.Entry(inf).State = EntityState.Added;
            return true;
        }

        public bool Remove(ISpecification<ClassTeacher> spec)
        {
            var entity = efCore.SqlContext.Set<ClassTeacher>().FirstOrDefault(spec.Expression);
            if (entity == null)
                return false;
            efCore.SqlContext.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        public IQueryable<ClassTeacher> QueryBySpec(ISpecification<ClassTeacher> spec)
        {
            return efCore.SqlContext.Set<ClassTeacher>().Where(spec.Expression);
        }
        #endregion
    }
}
