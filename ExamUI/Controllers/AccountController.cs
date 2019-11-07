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
using Application.Authentication;
using Infrastructure.Utils;

namespace ExamUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService userService;

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
                {
                    ModelState.AddModelError(string.Empty, "格式验证错误，请仔细核对输入项");
                    return View(model);
                }
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

        [HttpGet]
        public FileResult VerifyCodeBuilder()
        {
            string code = Common.Instance.GenCode(5);
            //将验证码加入session中
            var bytes = Common.Instance.Builder(code);
            return File(bytes, @"image/jpge");
        }
    }
}