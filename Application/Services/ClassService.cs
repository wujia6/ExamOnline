using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.IServices;
using Domain.Entities;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Query;
using AutoMapper.Execution;

namespace Application.Services
{
    public class ClassService<TSource, TDestination> : IClassService<TSource, TDestination> 
        where TSource : BaseEntity, IAggregateRoot 
        where TDestination : class
    {
        private readonly IClassManage<TSource> classManage;
        private readonly IExamDbContext context;

        public ClassService(IClassManage<TSource> manage, IExamDbContext cxt)
        {
            this.classManage = manage;
            this.context = cxt;
        }

        public bool AddOrEdit(TDestination model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<TSource>();
            return classManage.AddOrEdit(entity) ? context.SaveChanges() > 0 : false;
        }

        public bool Remove(Expression<Func<TSource, bool>> express)
        {
            var spec = Specification<TSource>.Eval(express);
            return classManage.Remove(spec) ? context.SaveChanges() > 0 : false;
        }

        public TDestination Single(Expression<Func<TSource, bool>> express = null, 
            Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null)
        {
            var spec = Specification<TSource>.Eval(express);
            var entity = classManage.Single(spec, include);
            return entity.MapTo<TDestination>();
        }

        public List<TDestination> Lists(Expression<Func<TSource, bool>> express = null, 
            Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null)
        {
            var spec = Specification<TSource>.Eval(express);
            var lst = classManage.Lists(spec, include);
            return lst.MapToList<TDestination>();
        }
    }

    public class ClassService : IClassService
    {
        private readonly IClassManage classManage;
        private readonly IExamDbContext context;

        public ClassService(IClassManage manage, IExamDbContext cxt)
        {
            this.classManage = manage;
            this.context = cxt;
        }

        public bool AddOrEdit<TSource>(TSource entity) where TSource : BaseEntity
        {
            if (entity==null)
                return false;
            return classManage.AddOrEdit(entity) ? context.SaveChanges() > 0 : false;
        }

        public bool Remove<TSource>(Expression<Func<TSource, bool>> express) where TSource : BaseEntity
        {
            var spec = Specification<TSource>.Eval(express);
            return classManage.Remove(spec) ? context.SaveChanges() > 0 : false;
        }

        public TDestination Single<TSource, TDestination>(Expression<Func<TSource, bool>> express,
            Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null) where TSource : BaseEntity
        {
            var spec = Specification<TSource>.Eval(express);
            return classManage.Single(spec, include).MapTo<TDestination>();
        }

        public List<TDestination> Lists<TSource, TDestination>(Expression<Func<TSource, bool>> express = null, 
            Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null) where TSource : BaseEntity
        {
            var spec = Specification<TSource>.Eval(express);
            var lst = classManage.Lists<TSource>(spec, include);
            return lst.MapToList<TDestination>();
        }
    }
}
