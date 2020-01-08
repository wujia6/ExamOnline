using System.Collections.Generic;
using System.Linq;
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
                    menus = BuilderTree(role.MenuDtos.AsQueryable(), null, 0);
                    //role.MenuDtos.ForEach(itm =>
                    //{
                    //    if (!menus.Contains(itm))
                    //        menus.Add(itm);
                    //});
                }
            }
            else
            {
                var role = roleService.Single(express: src => src.Code == roles,
                    include: src => src.Include(r => r.RoleMenus).ThenInclude(m => m.MenuInfomation));
                menus = BuilderTree(role.MenuDtos.AsQueryable(), null, 0);
            }
            return View(menus);
        }

        /// <summary>
        /// 递归生成菜单
        /// </summary>
        /// <param name="dtos">数据源</param>
        /// <param name="node">节点对象</param>
        /// <param name="id">层级ID</param>
        /// <returns></returns>
        private List<MenuDto> BuilderTree(IQueryable<MenuDto> dtos, MenuDto node, int id)
        {
            var lst = dtos.Where(x => x.ParentID == id).Select(src => new MenuDto
            {
                ID = src.ID,
                ParentID = src.ParentID,
                MenuType = src.MenuType,
                Title = src.Title,
                Controller = src.Controller,
                Action = src.Action,
                Remarks = src.Remarks
            }).Distinct().ToList();

            if (lst != null)
            {
                foreach (var item in lst)
                {
                    item.ChildNodes = BuilderTree(dtos, item, item.ID);
                }
            }
            return lst;
        }
    }
}
