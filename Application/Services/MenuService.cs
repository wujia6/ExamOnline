using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO.Models;
using Application.IServices;
using AutoMapper.Execution;
using Domain.Entities.MenuAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuManage menuManage;
        private readonly IExamDbContext context;

        public MenuService(IMenuManage manage, IExamDbContext cxt)
        {
            this.menuManage = manage;
            this.context = cxt;
        }

        public bool AddOrEdit(MenuDto model)
        {
            if (model == null)
                return false;
            return menuManage.AddOrEdit(model.MapTo<MenuInfo>());
        }

        public bool Remove(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return menuManage.Remove(spec);
        }

        public MenuDto FindBy(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return menuManage.FindBy(spec).MapTo<MenuDto>();
        }

        public List<MenuDto> Lists(
            out int total, 
            int? pageIndex = 1, 
            int? pageSize = 10, 
            Expression<Func<MenuInfo, bool>> express = null, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return menuManage.Lists(out total, pageIndex, pageSize, spec, include).MapToList<MenuDto>();
        }

        public List<MenuDto> Paginator(int? draw = 1, int? start = 0, int? length = 10)
        {
            
        }
    }
}
