using System.Collections.Generic;
using System.Linq;
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
                    menus = BuilderTree(role.MenuDtos, null, 0);
                }
            }
            else
            {
                var role = roleService.Single(express: src => src.Code == roles,
                    include: src => src.Include(r => r.RoleMenus).ThenInclude(m => m.MenuInfomation));
                menus = BuilderTree(role.MenuDtos, null, 0);
            }
            return View(menus);
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
            var menuList = dtos.Where(x => x.ParentID == id).Distinct().ToList();
            if (menuList != null && menuList.Count >0)
            {
                foreach (var node in menuList)
                {
                    node.ChildNodes = BuilderTree(dtos, node, node.ID);
                }
            }
            return menuList;
        }
    }
}
