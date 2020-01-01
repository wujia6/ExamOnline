﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.Execution;
using Application.DTO;
using Application.IServices;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Query;

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

        public bool AddOrEdit(AnswerDTO model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<AnswerInfo>();
            return answerManage.AddOrEdit(entity) ? context.SaveChanges() > 0 : false;
        }

        public bool Remove(Expression<Func<AnswerInfo, bool>> express)
        {
            var spec = Specification<AnswerInfo>.Eval(express);
            return answerManage.Remove(spec) ? context.SaveChanges() > 0 : false;
        }

        public AnswerDTO Single(Expression<Func<AnswerInfo, bool>> express = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null)
        {
            var spec = Specification<AnswerInfo>.Eval(express);
            var entity = answerManage.Single(spec, include);
            return entity.MapTo<AnswerDTO>();
        }

        public List<AnswerDTO> Lists(Expression<Func<AnswerInfo, bool>> express = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null)
        {
            var spec = Specification<AnswerInfo>.Eval(express);
            var lst = answerManage.Lists(spec, include);
            return lst.MapToList<AnswerInfo, AnswerDTO>();
        }
    }
}
