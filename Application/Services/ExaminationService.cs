using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.IServices;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Query;
using AutoMapper.Execution;
using Application.DTO.Models;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationManage examManage;
        private readonly IExamDbContext context;

        public ExaminationService(IExaminationManage manage, IExamDbContext cxt)
        {
            this.examManage = manage;
            this.context = cxt;
        }

        public async Task<bool> SaveAsync(ExaminationDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<ExaminationInfo>();
            return examManage.SaveAs(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> EditAsync(ExaminationDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<ExaminationInfo>();
            return examManage.EditTo(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> RemoveAsync(Expression<Func<ExaminationInfo, bool>> express)
        {
            var spec = Specification<ExaminationInfo>.Eval(express);
            return examManage.RemoveAt(spec) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<ExaminationDto> SingleAsync(
            Expression<Func<ExaminationInfo, bool>> express,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            var spec = Specification<ExaminationInfo>.Eval(express);
            var entity = await examManage.SingleAsync(spec);
            return entity.MapTo<ExaminationDto>();
        }

        public async Task<List<ExaminationDto>> QueryAsync(
            Expression<Func<ExaminationInfo, bool>> express = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<ExaminationInfo>.Eval(express);
            var entities = await examManage.QueryAsync(spec);
            return entities.MapToList<ExaminationDto>();
        }

        public async Task<PageResult<ExaminationDto>> QueryAsync(
            int index, int size,
            Expression<Func<ExaminationInfo, bool>> express = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<ExaminationInfo>.Eval(express);
            var anonymous = await examManage.QueryAsync(index, size, spec, include);
            return anonymous.ToPageResult<ExaminationDto>();
        }
    }
}
