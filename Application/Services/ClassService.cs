using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.IServices;
using Domain.Entities;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public class ClassService<TSource, TDest> : IClassService<TSource, TDest> 
        where TSource : BaseEntity, IAggregateRoot 
        where TDest : class
    {
        private readonly IClassManage<TSource> classManage;
        private readonly IExamDbContext context;

        public ClassService(IClassManage<TSource> manage, IExamDbContext cxt)
        {
            this.classManage = manage;
            this.context = cxt;
        }

        public bool AddOrEdit(TDest inf)
        {
            if (inf == null)
                return false;
            var entity = inf.MapTo<TSource>();
            return classManage.AddOrEdit(entity) ? context.SaveChanges() > 0 : false;
        }

        public bool Remove(Expression<Func<TSource, bool>> express)
        {
            var spec = Specification<TSource>.Eval(express);
            return classManage.Remove(spec) ? context.SaveChanges() > 0 : false;
        }

        public TDest Single(Expression<Func<TSource, bool>> express = null,
            Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null)
        {
            var spec = Specification<TSource>.Eval(express);
            return classManage.Single(spec, include).MapTo<TDest>();
        }

        public List<TDest> Lists(Expression<Func<TSource, bool>> express = null,
            Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null)
        {
            var spec = Specification<TSource>.Eval(express);
            return classManage.Lists(spec, include).MapToList<TDest>();
        }
    }
}
