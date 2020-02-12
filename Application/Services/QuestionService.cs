using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Application.IServices;
using AutoMapper.Execution;
using Domain.Entities.QuestionAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionManage questionManage;
        private readonly IExamDbContext context;

        public QuestionService(IQuestionManage manage, IExamDbContext cxt)
        {
            this.questionManage = manage;
            this.context = cxt;
        }

        public async Task<bool> SaveAsync(QuestionDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<QuestionInfo>();
            return questionManage.SaveAs(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> EditAsync(QuestionDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<QuestionInfo>();
            return questionManage.EditTo(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> RemoveAsync(Expression<Func<QuestionInfo, bool>> express)
        {
            var spec = Specification<QuestionInfo>.Eval(express);
            return questionManage.RemoveAt(spec) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<QuestionDto> SingleAsync(
            Expression<Func<QuestionInfo, bool>> express,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null)
        {
            var spec = Specification<QuestionInfo>.Eval(express);
            var entity = await questionManage.SingleAsync(spec, include);
            return entity.MapTo<QuestionDto>();
        }

        public async Task<List<QuestionDto>> QueryAsync(
            Expression<Func<QuestionInfo, bool>> express = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null)
        {
            var spec = Specification<QuestionInfo>.Eval(express);
            var lst = await questionManage.QueryAsync(spec, include);
            return lst.MapToList<QuestionDto>();
        }

        public async Task<PageResult<QuestionDto>> QueryAsync(
            int index, int size, 
            Expression<Func<QuestionInfo, bool>> express = null, 
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null)
        {
            var spec = Specification<QuestionInfo>.Eval(express);
            var anonymous = await questionManage.QueryAsync(index, size, spec, include);
            return anonymous.ToPageResult<QuestionDto>();
        }
    }
}
