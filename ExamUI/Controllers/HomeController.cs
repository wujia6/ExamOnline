using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ExamUI.Models;

namespace ExamUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var identityUser = userManager.GetUserAsync(HttpContext.User);
            //string userJson = User.FindFirst(ClaimTypes.UserData).Value;
            //CustomIdentity identity = User.Identity as CustomIdentity;
            //return RedirectToAction(nameof(AccountController.Login), "Account");
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
