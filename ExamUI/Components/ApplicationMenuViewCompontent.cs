using System.Collections.Generic;
using System.Threading.Tasks;
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

        public IViewComponentResult Invoke(string roles)
        {
            if (string.IsNullOrEmpty(roles))
                return View("~/Views/Shared/Error.cshtml");
            List<MenuDto> menus = null;
            if (roles.IndexOf(',') > 0)
            {
                menus = new List<MenuDto>();
                foreach (var code in roles.Split(','))
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
                var role = roleService.Single(express: src => src.Code == roles,
                    include: src => src.Include(r => r.RoleMenus).ThenInclude(m => m.MenuInfomation));
                menus = role.MenuDtos;
            }
            return View(menus);
        }
    }
}
