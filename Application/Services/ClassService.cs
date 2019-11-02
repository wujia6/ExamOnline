using System.Collections.Generic;
using Application.IServices;
using Domain.Entities;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utils;

namespace Application.Services
{
    public class ClassService<TSource, TDest> : IClassService<TSource, TDest> 
        where TSource : BaseEntity, IAggregateRoot 
        where TDest : class
    {
        private readonly IClassManage<TSource> classManage;
        private readonly IExamDbContext examContext;

        public ClassService(IClassManage<TSource> manage, IExamDbContext context)
        {
            this.classManage = manage;
            this.examContext = context;
        }

        public bool AddOrEdit(TDest inf)
        {
            if (inf == null)
                return false;
            var entity = inf.MapTo<TSource>();
            return classManage.AddOrEdit(entity) ? examContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<TSource> spec)
        {
            return classManage.Remove(spec) ? examContext.SaveChanges() > 0 : false;
        }

        public TDest FindBy(ISpecification<TSource> spec)
        {
            return classManage.FindBy(spec).MapTo<TDest>();
        }

        public List<TDest> QuerySet(ISpecification<TSource> spec)
        {
            return classManage.QuerySet(spec).MapToList<TDest>();
        }
    }
}
