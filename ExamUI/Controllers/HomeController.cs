using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ExamUI.Models;
using System.Security.Claims;
using Application.IServices;

namespace ExamUI.Controllers
{
    [Authorize(Roles ="admin,teacher,student")]
    public class HomeController : Controller
    {
        private readonly IMenuService menuService;

        public HomeController(IMenuService service)
        {
            this.menuService = service;
        }

        public IActionResult Index()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid));
            string userName = User.FindFirstValue(ClaimTypes.Name);
            string roles = User.FindFirstValue(ClaimTypes.Role);
            return View();
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
