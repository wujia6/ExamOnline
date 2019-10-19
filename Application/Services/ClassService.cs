using System.Collections.Generic;
using Application.IServices;
using Domain.Entities.ClassAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utils;

namespace Application.Services
{
    internal class ClassService<TSource, TDest> : IClassService<TSource, TDest> 
        where TSource : ClassRoot 
        where TDest : class
    {
        private readonly IClassManage<TSource> classManage;
        private readonly IExamDbContext examContext;

        public ClassService(IClassManage<TSource> manage, IExamDbContext context)
        {
            this.classManage = manage;
            this.examContext = context;
        }

        public bool InsertOrUpdate(TDest inf)
        {
            if (inf == null)
                return false;
            var entity = inf.MapTo<TSource>();
            return classManage.InsertOrUpdate(entity) ? examContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<TSource> spec)
        {
            return classManage.Remove(spec);
        }

        public TDest Single(ISpecification<TSource> spec)
        {
            return classManage.FindBySpec(spec).MapTo<TDest>();
        }

        public List<TDest> Query(ISpecification<TSource> spec)
        {
            return classManage.QueryBySpec(spec).MapToList<TDest>();
        }
    }
}
