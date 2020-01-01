﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO;
using Application.IServices;
using AtuoMapper;
using Domain.Entities.QuestionAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
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

        public bool AddOrEdit(QuestionDTO model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<QuestionInfo>();
            return questionManage.AddOrEdit(entity) ? context.SaveChanges() > 0 : false;
        }

        public bool Remove(Expression<Func<QuestionInfo, bool>> express)
        {
            var spec = Specification<QuestionInfo>.Eval(express);
            return questionManage.Remove(spec) ? context.SaveChanges() > 0 : false;
        }

        public QuestionDTO Single(Expression<Func<QuestionInfo, bool>> express = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null)
        {
            var spec = Specification<QuestionInfo>.Eval(express);
            var entity = questionManage.Single(spec, include);
            return entity.MapTo<QuestionDTO>();
        }

        public List<QuestionDTO> Lists(Expression<Func<QuestionInfo, bool>> express = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null)
        {
            var spec = Specification<QuestionInfo>.Eval(express);
            var lst = questionManage.Lists(spec, include);
            return lst.MapToList<QuestionDTO>();
        }
    }
}
