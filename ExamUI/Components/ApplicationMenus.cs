using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using Application.DTO.Models;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

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
            this.roleService = service;
            this.appCache = cache;
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
            if (!appCache.TryGetValue("ApplicationMenus",out object cacheValue))
            {
                var lst= ReadMenusBy(fromRoles);
                appCache.Set("ApplicationMenus", lst, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(20),  //设置缓存绝对过期时间
                    Priority = CacheItemPriority.Normal   //设置缓存优先级
                });
            }
            var menus = appCache.Get("ApplicationMenus") as List<MenuDto>;
            return View(menus);
        }

        /// <summary>
        /// 查询角色菜单
        /// </summary>
        /// <param name="fromRoles">角色字符串</param>
        /// <returns></returns>
        private async Task<List<MenuDto>> ReadMenusBy(string fromRoles)
        {
            List<MenuDto> menus = null;
            if (fromRoles.IndexOf(',') > 0)
            {
                foreach (var code in fromRoles.Split(','))
                {
                    var role = await roleService.SingleAsync(express: src => src.Code == code,
                        include: src => src.Include(r => r.RoleMenus).ThenInclude(m => m.MenuInfomation));
                    menus = BuilderTree(role.MenuDtos, null, 0);
                }
            }
            else
            {
                var role = await roleService.SingleAsync(express: src => src.Code == fromRoles,
                    include: src => src.Include(r => r.RoleMenus).ThenInclude(m => m.MenuInfomation));
                menus = BuilderTree(role.MenuDtos, null, 0);
            }
            return menus;
        }

        /// <summary>
        /// 递归生成菜单
        /// </summary>
        /// <param name="dtos">数据源</param>
        /// <param name="treeNode">节点对象</param>
        /// <param name="id">层级ID</param>
        /// <returns></returns>
        private List<MenuDto> BuilderTree(List<MenuDto> dtos, MenuDto treeNode, int id)
        {
            var menus = dtos.Where(x => x.ParentID == id).Distinct().ToList();
            if (menus != null && menus.Count > 0)
            {
                foreach (var node in menus)
                {
                    node.ChildNodes = BuilderTree(dtos, node, node.ID);
                }
            }
            return menus;
        }
    }
}
