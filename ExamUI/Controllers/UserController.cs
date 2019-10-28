using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamUI.Models;
using Microsoft.AspNetCore.Mvc;
using Application.IServices;
using Domain.Entities.UserAgg;
using Application.DTO;
using Domain.IComm;
using Infrastructure.Utils;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ExamUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService<UserInfo, UserDTO> userService;

        //依赖注入
        public UserController(IUserService<UserInfo, UserDTO> service)
        {
            this.userService = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { result = false, message = "账号或密码格式错误" });
            var loginer = userService.QueryBySet(express: usr => usr.Account == model.Account && usr.Pwd == model.Password);
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name,model.Account),
                new Claim("password",model.Password)
            };
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims,"ApplicationUser"));
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(model.ExpireMin),
                IsPersistent = true,
                AllowRefresh = true
            });
            return RedirectToAction(nameof(HomeController.Index), "Home");   
        }

        [HttpPost]
        public IActionResult Register()
        {
            return View();
        }
    }
}