using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.Execution;
using Application.IServices;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Query;
using Application.DTO.Models;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerManage answerManage;
        private readonly IExamDbContext context;

        public AnswerService(IAnswerManage manage, IExamDbContext cxt)
        {
            this.answerManage = manage;
            this.context = cxt;
        }

        public async Task<bool> SaveAsync(AnswerDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<AnswerInfo>();
            return answerManage.SaveAs(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> EditAsync(AnswerDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<AnswerInfo>();
            return answerManage.EditTo(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> RemoveAsync(Expression<Func<AnswerInfo, bool>> express)
        {
            var spec = Specification<AnswerInfo>.Eval(express);
            return answerManage.RemoveAt(spec) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<AnswerDto> SingleAsync(
            Expression<Func<AnswerInfo, bool>> express,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null)
        {
            var spec = Specification<AnswerInfo>.Eval(express);
            var entity = await answerManage.SingleAsync(spec);
            return entity.MapTo<AnswerDto>();
        }

        public async Task<List<AnswerDto>> QueryAsync(
            Expression<Func<AnswerInfo, bool>> express = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<AnswerInfo>.Eval(express);
            var entities = await answerManage.QueryAsync(spec);
            return entities.MapToList<AnswerDto>();
        }

        public async Task<PageResult<AnswerDto>> QueryAsync(
            int index, int size,
            Expression<Func<AnswerInfo, bool>> express = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<AnswerInfo>.Eval(express);
            var anonymous = await answerManage.QueryAsync(index, size, spec, include);
            return anonymous.ToPageResult<AnswerDto>();
        }
    }
}
