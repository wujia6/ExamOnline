using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using Application.IServices;
using Infrastructure.Utils;
using Application.DTO;
using Domain.Entities;

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
        public FileResult VerifyCodeBuilder()
        {
            string code = Common.Instance.GenCode(5);
            //将验证码加入session中
            HttpContext.Session.SetString("vcode", code);
            var bytes = Common.Instance.Builder(code);
            return File(bytes, @"image/jpge");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl=null)    //这个returnUrl一般用于做单点登陆的认证中心回调地址
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> Login(Models.ApplicationUser model)
        {
            try
            {
                //if (!ModelState.IsValid)
                //    return Json(new { result = false, message = "用户名或密码格式错误" });
                var userInfo = userService.FindBy(express: usr => usr.Account == model.Account && usr.Pwd == model.Password);
                if (userInfo == null)
                    return Json(new { result = false, message = "错误的账号或密码" });
                //获取用户角色
                string roleCodes = string.Empty;
                userInfo.UserRoleDtos.ForEach(x => roleCodes += x.RoleDto.Code + ",");
                roleCodes = roleCodes.Remove(roleCodes.LastIndexOf(','), 1);
                //创建身份证件单元：一张身份证由许多证件单元组成
                //创建身份证件，添加证件单元
                //创建身份证件使用者，添加身份证
                var identitys = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Sid,userInfo.ID.ToString()),
                    new Claim(ClaimTypes.Name,model.Account),
                    //new Claim("Password",model.Password),
                    new Claim(ClaimTypes.Role,roleCodes),
                    new Claim(ClaimTypes.UserData,JsonConvert.SerializeObject(userInfo.UserRoleDtos))
                });
                //写入客户端cookie
                await HttpContext.SignInAsync(identitys.AuthenticationType, new ClaimsPrincipal(identitys), new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(model.ExpireMin),
                    IsPersistent = true,
                    AllowRefresh = true
                });
                return Json(new { result = true, message = "登录成功", path = "/Home/Index" });
            }
            catch (Exception ex)
            {
                //return LocalRedirect("~/Views/Shared/Error.cshtml");
                throw ex;
            }
        }
    }
}