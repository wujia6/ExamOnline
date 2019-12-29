using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO;
using Application.IServices;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Query;
using AutoMapper;

namespace Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamManage examManage;
        private readonly IExamDbContext context;
        private readonly IMapper mapper;

        public ExamService(IExamManage manage, IExamDbContext cxt, IMapper map)
        {
            this.examManage = manage;
            this.context = cxt;
            this.mapper = map;
        }

        public bool AddOrEdit(ExaminationDTO model)
        {
            if (model == null)
                return false;
            var entity = mapper.Map<ExaminationInfo>(model);
            return examManage.AddOrEdit(entity) ? context.SaveChanges() > 0 : false;
        }

        public bool Remove(Expression<Func<ExaminationInfo, bool>> express)
        {
            var spec = Specification<ExaminationInfo>.Eval(express);
            return examManage.Remove(spec) ? context.SaveChanges() > 0 : false;
        }

        public ExaminationDTO Single(Expression<Func<ExaminationInfo, bool>> express = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            var spec = Specification<ExaminationInfo>.Eval(express);
            return mapper.Map<ExaminationDTO>(examManage.Single(spec, include));
        }

        public List<ExaminationDTO> Lists(Expression<Func<ExaminationInfo, bool>> express = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            var spec = Specification<ExaminationInfo>.Eval(express);
            return mapper.Map<List<ExaminationDTO>>(examManage.Single(spec, include));

        }
    }
}
