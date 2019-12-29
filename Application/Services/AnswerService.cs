using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO;
using Application.IServices;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Application.DTO.Mappings;
using Microsoft.EntityFrameworkCore.Query;
using AutoMapper;

namespace Application.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerManage answerManage;
        private readonly IExamDbContext context;
        private readonly IMapper mapper;

        public AnswerService(IAnswerManage manage, IExamDbContext cxt, IMapper map)
        {
            this.answerManage = manage;
            this.context = cxt;
            this.mapper = map;
        }

        public bool AddOrEdit(AnswerDTO model)
        {
            if (model == null)
                return false;
            var entity = mapper.Map<AnswerInfo>(model);
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
            return mapper.Map<AnswerDTO>(answerManage.Single(spec, include));
        }

        public List<AnswerDTO> Lists(Expression<Func<AnswerInfo, bool>> express = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null)
        {
            var spec = Specification<AnswerInfo>.Eval(express);
            return mapper.Map<List<AnswerDTO>>(answerManage.Lists(spec, include));
        }
    }
}
