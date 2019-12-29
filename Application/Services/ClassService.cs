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
using AutoMapper;

namespace Application.Services
{
    public class ClassService<TSource, TDestination> : IClassService<TSource, TDestination> 
        where TSource : BaseEntity, IAggregateRoot 
        where TDestination : class
    {
        private readonly IClassManage<TSource> classManage;
        private readonly IExamDbContext context;
        private readonly IMapper mapper;

        public ClassService(IClassManage<TSource> manage, IExamDbContext cxt, IMapper map)
        {
            this.classManage = manage;
            this.context = cxt;
            this.mapper = map;
        }

        public bool AddOrEdit(TDestination model)
        {
            if (model == null)
                return false;
            var entity = mapper.Map<TSource>(model);
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
            return mapper.Map<TDestination>(classManage.Single(spec, include));
        }

        public List<TDestination> Lists(Expression<Func<TSource, bool>> express = null,
            Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null)
        {
            var spec = Specification<TSource>.Eval(express);
            return mapper.Map<List<TDestination>>(classManage.Single(spec, include));
        }
    }
}
