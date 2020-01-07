using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Application.IServices;
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
                //int userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid));
                ViewBag.UserName = User.FindFirstValue(ClaimTypes.Name);
                ViewBag.InRoles = User.FindFirstValue(ClaimTypes.Role);
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
