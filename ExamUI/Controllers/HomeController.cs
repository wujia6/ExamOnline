using System.Diagnostics;
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

                var applicationMenus = new List<MenuDto>();
                if (roles.IndexOf(',') > 0)
                {
                    foreach (var code in roles.Split(','))
                    {
                        var role = roleService.Single(express: r => r.Code == code,
                            include: src => src.Include(m => m.RoleMenus).ThenInclude(s => s.MenuInfomation));
                        applicationMenus.AddRange(role.MenuDtos);
                    }
                }
                else
                {
                    var role = roleService.Single(express: r => r.Code == roles,
                        include: src => src.Include(m => m.RoleMenus).ThenInclude(s => s.MenuInfomation));
                    applicationMenus.AddRange(role.MenuDtos);
                }
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
    }
}
