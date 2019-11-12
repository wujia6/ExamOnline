using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ExamUI.Models;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Collections.Generic;
using Application.DTO;

namespace ExamUI.Controllers
{
    [Authorize(Roles ="admin,teacher,student")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid));
            string userName = User.FindFirstValue(ClaimTypes.Name);
            string roles = User.FindFirstValue(ClaimTypes.UserData);
            var lstRoles = JsonConvert.DeserializeObject<List<UserRoleDTO>>(roles);
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
