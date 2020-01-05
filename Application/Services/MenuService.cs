using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTO.Models;
using Application.IServices;
using AutoMapper.Execution;
using Domain.Entities.MenuAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;

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

        public bool AddOrEdit(MenuInfo entity)
        {
            if (entity == null)
                return false;
            return menuManage.AddOrEdit(entity);
        }

        public MenuDto FindBy(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return menuManage.FindBy(spec).MapTo<MenuDto>();
        }

        public IEnumerable<MenuDto> Lists(Expression<Func<MenuInfo, bool>> express = null)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return menuManage.Lists(spec).MapToList<MenuDto>();
        }

        public bool Remove(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return menuManage.Remove(spec);
        }
    }
}
