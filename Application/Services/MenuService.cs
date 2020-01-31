using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        #region ### async
        public async Task<bool> SaveAsync(MenuDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<MenuInfo>();
            return menuManage.SaveAs(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> EditAsync(MenuDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<MenuInfo>();
            return menuManage.EditTo(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> RemoveAsync(Expression<Func<MenuInfo, bool>> express)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            return menuManage.RemoveAt(spec) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<MenuDto> SingleAsync(
            Expression<Func<MenuInfo, bool>> express, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            var spec = Specification<MenuInfo>.Eval(express);
            var entity = await menuManage.SingleAsync(spec);
            return entity.MapTo<MenuDto>();
        }

        public async Task<List<MenuDto>> QueryAsync(
            Expression<Func<MenuInfo, bool>> express = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
           var spec = express == null ? null : Specification<MenuInfo>.Eval(express);
            var lsts = await menuManage.QueryAsync(spec);
            return lsts.MapToList<MenuDto>();
        }

        public async Task<PageResult<MenuDto>> QueryAsync(
            int index, int size, 
            Expression<Func<MenuInfo, bool>> express = null, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<MenuInfo>.Eval(express);
            var anonymous = await menuManage.QueryAsync(index, size, spec, include);
            return anonymous.ToPageResult<MenuDto>();
        }
        #endregion
    }
}
