using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamUI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Application.Authentication;

namespace ExamUI.Controllers
{
    public class HomeController : Controller
    { 
        public IActionResult Index()
        {
            //var identityUser = userManager.GetUserAsync(HttpContext.User);
            //string userJson = User.FindFirst(ClaimTypes.UserData).Value;
            //CustomIdentity identity = User.Identity as CustomIdentity;
            return RedirectToAction(nameof(AccountController.Login), "Account");
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
