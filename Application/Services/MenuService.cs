using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Application.IServices;
using AutoMapper.Execution;
using Domain.Entities;
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

        public bool Save(MenuDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<MenuInfo>();
            return menuManage.Save(entity);
        }

        public bool Edit(MenuDto model)
        {
            if (model == null)
                return false;
            return menuManage.Edit(model.MapTo<MenuInfo>());
        }

        public bool Remove(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return menuManage.Remove(spec);
        }

        public MenuDto Single(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return menuManage.Single(spec).MapTo<MenuDto>();
        }

        public List<MenuDto> Lists(
            out int total, 
            int? index = 1, 
            int? size = 10, 
            Expression<Func<MenuInfo, bool>> express = null, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return menuManage.Lists(out total, index, size, spec, include).MapToList<MenuDto>();
        }

        public async Task<bool> SaveAsync(MenuDto model)
        {
            var entity = model.MapTo<MenuInfo>();
            return await menuManage.SaveAsync(entity);
        }

        public async Task<bool> EditAsync(MenuDto model)
        {
            var entity = model.MapTo<MenuInfo>();
            return await menuManage.EditAsync(entity);
        }

        public async Task<bool> RemoveAsync(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return await menuManage.RemoveAsync(spec);
        }

        public async Task<MenuDto> SingleAsync(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            var entity = await menuManage.SingleAsync(spec);
            return entity.MapTo<MenuDto>();
        }

        public async Task<List<MenuDto>> QueryByAsync(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            var menus = await menuManage.QueryByAsync(spec);
            return menus.MapToList<MenuDto>();
        }

        public async Task<PageResult> ListsAsync(
            int? index = 1, 
            int? size = 10, 
            Expression<Func<MenuInfo, bool>> express = null, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            var result = await menuManage.ListsAsync(index, size, spec, include);
            result.Rows = result.Rows.MapToList<MenuDto>();
            return result;
        }
    }
}
