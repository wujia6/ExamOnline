using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using Application.DTO.Models;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ExamUI.Components
{
    /// <summary>
    /// 系统菜单视图组件类
    /// </summary>
    [ViewComponent(Name = "ApplicationMenus")]
    public class ApplicationMenus : ViewComponent
    {
        private readonly IRoleService roleService;
        private readonly IMemoryCache appCache;

        public ApplicationMenus(IRoleService service, IMemoryCache cache)
        {
            this.roleService = service ?? throw new ArgumentNullException(nameof(roleService));
            this.appCache = cache ?? throw new ArgumentNullException(nameof(appCache));
        }

        /// <summary>
        /// 回调方法
        /// </summary>
        /// <param name="roles">角色字符串</param>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            ViewBag.CurrentUser = UserClaimsPrincipal.FindFirstValue(ClaimTypes.Name);
            string fromRoles = UserClaimsPrincipal.FindFirstValue(ClaimTypes.Role);
            //缓存角色菜单
            if (!(appCache.Get("ApplicationMenus") is List<MenuDto> appMenus) || appMenus.Count == 0)
            {
                //appMenus = ReadRoleMenus(fromRoles);
                appMenus = null;
                appCache.Set("ApplicationMenus", appMenus, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(20),  //设置缓存绝对过期时间
                    Priority = CacheItemPriority.Normal   //设置缓存优先级
                });
            }
            return View(appMenus);
        }

        /// <summary>
        /// 查询角色菜单
        /// </summary>
        /// <param name="fromRoles">角色字符串</param>
        /// <returns></returns>
        //private List<MenuDto> ReadRoleMenus(string fromRoles)
        //{
        //    List<MenuDto> appMenus = null;
        //    if (fromRoles.IndexOf(',') > 0)
        //    {
        //        foreach (var code in fromRoles.Split(','))
        //        {
        //            var dtoRole = roleService.SingleIn(express: src => src.Code == code,
        //                include: src => src.Include(r => r.RoleMenus).ThenInclude(m => m.MenuInfomation));
        //            appMenus = BuilderTree(dtoRole.MenuDtos, null, 0);
        //        }
        //    }
        //    else
        //    {
        //        var dtoRole = roleService.SingleIn(express: src => src.Code == fromRoles, 
        //            include: src => src.Include(r => r.RoleMenus).ThenInclude(m => m.MenuInfomation));
        //        appMenus = BuilderTree(dtoRole.MenuDtos, null, 0);
        //    }
        //    return appMenus;
        //}

        /// <summary>
        /// 递归生成菜单
        /// </summary>
        /// <param name="dtos">数据源</param>
        /// <param name="treeNode">节点对象</param>
        /// <param name="levelID">层级ID</param>
        /// <returns></returns>
        //private List<MenuDto> BuilderTree(List<MenuDto> dtos, MenuDto treeNode, int levelID)
        //{
        //    var appMenus = dtos.Where(x => x.ParentID == levelID).Distinct().ToList();
        //    if (appMenus != null && appMenus.Count > 0)
        //    {
        //        foreach (var node in appMenus)
        //        {
        //            node.ChildNodes = BuilderTree(dtos, node, node.ID);
        //        }
        //    }
        //    return appMenus;
        //}
    }
}
