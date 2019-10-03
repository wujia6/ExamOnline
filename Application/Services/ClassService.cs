using System.Linq;
using Application.IServices;
using Domain.Entities.ClassAgg;
using Domain.IComm;
using Domain.IManages;

namespace Application.Services
{
    internal class ClassService : IClassService
    {
        private readonly IClassManage classManage;
        private readonly ISqlContext sqlContext;

        public ClassService(IClassManage manage, ISqlContext context)
        {
            this.classManage = manage;
            this.sqlContext = context;
        }

        public bool Insert(ClassExam inf)
        {
            return inf == null ? false : classManage.Insert(inf);
        }

        public bool Insert(ClassTeacher inf)
        {
            return inf == null ? false : classManage.Insert(inf);
        }

        public bool InsertOrUpdate(ClassInfo inf)
        {
            if (inf == null)
                return false;
            return classManage.InsertOrUpdate(inf) ? sqlContext.SaveChanges() > 0 : false;
        }

        public IQueryable<ClassInfo> Query(ISpecification<ClassInfo> spec)
        {
            return classManage.QueryBySpec(spec);
        }

        public IQueryable<ClassExam> Query(ISpecification<ClassExam> spec)
        {
            return classManage.QueryBySpec(spec);
        }

        public IQueryable<ClassTeacher> Query(ISpecification<ClassTeacher> spec)
        {
            return classManage.QueryBySpec(spec);
        }

        public bool Remove(ISpecification<ClassInfo> spec)
        {
            return classManage.Remove(spec);
        }

        public bool Remove(ISpecification<ClassExam> spec)
        {
            return classManage.Remove(spec);
        }

        public bool Remove(ISpecification<ClassTeacher> spec)
        {
            return classManage.Remove(spec);
        }

        public ClassInfo Single(ISpecification<ClassInfo> spec)
        {
            return classManage.FindBySpec(spec);
        }
    }
}
