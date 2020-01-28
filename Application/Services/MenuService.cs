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

        #region ### async
        public async Task<bool> SaveAsync(MenuDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<MenuInfo>();
            return menuManage.Save(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> EditAsync(MenuDto model)
        {
            if (model==null)
                return false;
            var entity = model.MapTo<MenuInfo>();
            return menuManage.Edit(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> RemoveAsync(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return menuManage.Remove(spec) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<MenuDto> SingleAsync(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            var entity = await menuManage.SingleAsync(spec);
            return entity.MapTo<MenuDto>();
        }

        public async Task<List<MenuDto>> QuerysAsync(Expression<Func<MenuInfo, bool>> express = null)
        {
            var spec = express == null ? null : Specification<MenuInfo>.Eval(express);
            return await Task.Run(() => menuManage.QuerySet(spec).MapToList<MenuDto>());
        }

        public async Task<PagingResult<MenuDto>> ListsAsync(
            int? index, 
            int? size, 
            Expression<Func<MenuInfo, bool>> express = null, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<MenuInfo>.Eval(express);
            var result = await menuManage.ListsAsync(index, size, spec, include);
            return new PagingResult<MenuDto> { Total = result.Total, Rows = result.Rows.MapToList<MenuDto>() };
        }
        #endregion
    }
}
