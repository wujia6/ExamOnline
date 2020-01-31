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
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities.ClassAgg;

namespace Application.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassManage classManage;
        private readonly IExamDbContext context;

        public ClassService(IClassManage manage, IExamDbContext cxt)
        {
            this.classManage = manage;
            this.context = cxt;
        }

        public async Task<bool> SaveAsync(ClassDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<ClassInfo>();
            return classManage.SaveAs(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> EditAsync(ClassDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<ClassInfo>();
            return classManage.EditTo(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> RemoveAsync(Expression<Func<ClassInfo, bool>> express)
        {
            var spec = Specification<ClassInfo>.Eval(express);
            return classManage.RemoveAt(spec) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<ClassDto> SingleAsync(
            Expression<Func<ClassInfo, bool>> express,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null)
        {
            var spec = Specification<ClassInfo>.Eval(express);
            var entity = await classManage.SingleAsync(spec);
            return entity.MapTo<ClassDto>();
        }

        public async Task<List<ClassDto>> QueryAsync(
            Expression<Func<ClassInfo, bool>> express = null,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<ClassInfo>.Eval(express);
            var entities = await classManage.QueryAsync(spec);
            return entities.MapToList<ClassDto>();
        }

        public async Task<PageResult<ClassDto>> QueryAsync(
            int index, int size,
            Expression<Func<ClassInfo, bool>> express = null,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<ClassInfo>.Eval(express);
            var anonymous = await classManage.QueryAsync(index, size, spec, include);
            return anonymous.ToPageResult<ClassDto>();
        }
    }
}
