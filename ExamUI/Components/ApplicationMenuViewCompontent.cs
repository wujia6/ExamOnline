using System.Collections.Generic;
using System.Security.Claims;
using Application.DTO.Models;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamUI.Components
{
    /// <summary>
    /// 系统菜单视图组件类
    /// </summary>
    [ViewComponent(Name = "ApplicationMenu")]
    public class ApplicationMenuViewCompontent : ViewComponent
    {
        private readonly IRoleService roleService;

        public ApplicationMenuViewCompontent(IRoleService service)
        {
            this.roleService = service;
        }

        public IViewComponentResult Invoke()
        {
            int userId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.Sid));
            string userName = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            string roles = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            if (string.IsNullOrEmpty(roles))
                return View("~/Views/Shared/Error.cshtml");
            var appMenus = ApplicationMenus(roles);
            return View(appMenus);
        }

        /// <summary>
        /// 获取角色菜单
        /// </summary>
        /// <param name="roleCodes">角色字符串</param>
        /// <returns></returns>
        private List<MenuDto> ApplicationMenus(string roleCodes)
        {
            List<MenuDto> menus = null;
            if (roleCodes.IndexOf(',') > 0)
            {
                menus = new List<MenuDto>();
                foreach (var code in roleCodes.Split(','))
                {
                    var role = roleService.Single(express: src => src.Code == code,
                        include: src => src.Include(r => r.RoleMenus).ThenInclude(m => m.MenuInfomation));
                    role.MenuDtos.ForEach(itm =>
                    {
                        if (!menus.Contains(itm))
                            menus.Add(itm);
                    });
                }
            }
            else
            {
                var role = roleService.Single(express: src => src.Code == roleCodes,
                        include: src => src.Include(r => r.RoleMenus).ThenInclude(m => m.MenuInfomation));
                menus = role.MenuDtos;
            }
            return menus;
        }
    }
}
