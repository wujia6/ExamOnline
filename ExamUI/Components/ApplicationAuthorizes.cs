using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Application.DTO.Models;
using Application.IServices;
using Infrastructure.Utils;
using System.Linq;

namespace ExamUI.Components
{
    [ViewComponent(Name = "ApplicationAuthorizes")]
    public class ApplicationAuthorizes : ViewComponent
    {
        private readonly IRoleService roleSvr;
        private readonly IMemoryCache appCache;

        public ApplicationAuthorizes(IRoleService svr, IMemoryCache cache)
        {
            this.roleSvr = svr ?? throw new ArgumentNullException(nameof(roleSvr));
            this.appCache = cache ?? throw new ArgumentNullException(nameof(appCache));
        }

        /// <summary>
        /// 系统回调
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            ViewBag.CurrentUser = UserClaimsPrincipal.FindFirstValue(ClaimTypes.Name);
            string appRoles = UserClaimsPrincipal.FindFirstValue(ClaimTypes.Role);
            //缓存角色授权
            if (!(appCache.Get("AppRoleAuthorizes") is List<PermissionDto> AppRoleAuthorizes))
            {
                AppRoleAuthorizes = GetRoleAuthorizeBy(appRoles);
                appCache.Set("AppRoleAuthorizes", AppRoleAuthorizes, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),  //设置缓存绝对过期时间
                    Priority = CacheItemPriority.Normal   //设置缓存优先级
                });
            }
            return View(AppRoleAuthorizes);
        }

        /// <summary>
        /// 获取角色授权
        /// </summary>
        /// <param name="roles">角色(多个之间用,分割)</param>
        /// <returns></returns>
        private List<PermissionDto> GetRoleAuthorizeBy(string roles)
        {
            List<PermissionDto> authorizes = null;
            if (roles.IndexOf(',') > 0)
            {
                foreach (var code in roles.Split(','))
                {
                    var currRole = roleSvr.SingleIn(
                        express: src => src.Code == code, 
                        include: src => src.Include(s => s.RoleAuthorizes).ThenInclude(d => d.PermissionInformation));
                    authorizes = CreateAuthorizeRoot(currRole.PermssionDtos);
                }
            }
            else
            {
                var currRole = roleSvr.SingleIn(
                    express: src => src.Code == roles,
                    include: src => src.Include(s => s.RoleAuthorizes).ThenInclude(d => d.PermissionInformation));
                authorizes = CreateAuthorizeRoot(currRole.PermssionDtos);
            }
            return authorizes;
        }

        /// <summary>
        /// 递归生成授权导航
        /// </summary>
        /// <param name="srcList">数据源</param>
        /// <param name="levelId">层级ID</param>
        /// <returns></returns>
        private List<PermissionDto> CreateAuthorizeRoot(List<PermissionDto> srcList, int levelId = 0)
        {
            var matchs = srcList.Where(x => x.LevelID == levelId);
            if (matchs == null || matchs.Count() == 0)
                return null;
            foreach (var item in matchs)
            {
                item.Childs = CreateAuthorizeRoot(srcList, item.ID);
            } 
            return matchs.ToList();
        }
    }
}
