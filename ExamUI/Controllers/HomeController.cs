﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Application.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Application.DTO.Models;

namespace ExamUI.Controllers
{
    [Authorize(Roles ="admin,teacher,student")]
    public class HomeController : Controller
    {
        private readonly IRoleService roleService;

        public HomeController(IRoleService service)
        {
            this.roleService = service;
        }

        public IActionResult Index()
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid));
                string userName = User.FindFirstValue(ClaimTypes.Name);
                string roles = User.FindFirstValue(ClaimTypes.Role);
                
                if (string.IsNullOrEmpty(roles))
                    return LocalRedirect("~/Views/Shared/Error.cshtml");
                var appMenus = ApplicationMenus(roles);
                return View();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
