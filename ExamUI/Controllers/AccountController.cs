using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ExamUI.Models;
using Application.IServices;
using Domain.Entities.UserAgg;
using Application.DTO;

namespace ExamUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService<UserInfo, UserDTO> userService;

        public AccountController(IUserService<UserInfo, UserDTO> service)
        {
            userService = service;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl="")
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { result = false, message = "输入错误，请重新输入！" });

                var appUser = userService.FindBy(express: usr => usr.Account == model.Account && usr.Pwd == model.Password);

                if (appUser == null)
                    return Json(new { result = false, message = "错误的账号或密码！" });

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,model.Account),
                    new Claim("password",model.Password)
                };
                var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "ApplicationUser"));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(model.ExpireMin),
                    IsPersistent = false,
                    AllowRefresh = false
                });
                return RedirectToAction(nameof(HomeController.Index));
            }
            catch (Exception ex)
            {
                return LocalRedirect("~/View/Shared/Error.cshtml");
            }
        }
    }
}