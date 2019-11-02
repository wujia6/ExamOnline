using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using ExamUI.Models;
using Application.IServices;
using Domain.Entities.UserAgg;
using Application.DTO;
using Application.Authentication;

namespace ExamUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IUserService userService;
        public AccountController(IUserService service)
        {
            userService = service;
        }

        [HttpGet]
        public IActionResult Register(string returnUrl=null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl=null)    //这个returnUrl一般用于做单点登陆的认证中心回调地址
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { result = false, message = "账号或密码格式错误" });

                var userInfo = userService.FindBy(express: usr => usr.Account == model.Account && usr.Pwd == model.Password);

                if (userInfo == null)
                    return Json(new { result = false, message = "错误的账号或密码" });
                //获取用户角色集合
                //string roles = string.Empty;
                //userInfo.UserRoleDtos.ForEach(x => roles += x.RoleDto.ID + ",");
                //roles.Remove(-1, 1);
                //创建身份证件单元：一张身份证由许多证件单元组成
                //创建身份证件，添加证件单元
                //创建身份证件使用者，添加身份证
                //var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>{
                //    new Claim(ClaimTypes.Sid,userInfo.ID.ToString()),
                //    new Claim(ClaimTypes.Name,model.Account),
                //    new Claim("password",model.Password),
                //    new Claim(ClaimTypes.Role,roles),
                //    new Claim(ClaimTypes.UserData,JsonConvert.SerializeObject(userInfo.UserRoleDtos))
                //}));
                var identity = new CustomIdentity(new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(userInfo.UserRoleDtos)));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(model.ExpireMin),
                    IsPersistent = true,
                    AllowRefresh = true
                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            catch (Exception)
            {
                return LocalRedirect("~/View/Shared/Error.cshtml");
            }
        }
    }
}