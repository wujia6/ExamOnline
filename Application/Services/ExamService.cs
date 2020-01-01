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
using AutoMapper.Execution;

namespace Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamManage examManage;
        private readonly IExamDbContext context;

        public ExamService(IExamManage manage, IExamDbContext cxt)
        {
            this.examManage = manage;
            this.context = cxt;
        }

        public bool AddOrEdit(ExaminationDTO model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<ExaminationInfo>();
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
            var entity = examManage.Single(spec, include);
            return entity.MapTo<ExaminationDTO>();
        }

        public List<ExaminationDTO> Lists(Expression<Func<ExaminationInfo, bool>> express = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            var spec = Specification<ExaminationInfo>.Eval(express);
            var lst = examManage.Lists(spec, include);
            return lst.MapToList<ExaminationDTO>();

        }
    }
}
