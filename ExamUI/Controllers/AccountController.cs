using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Application.IServices;
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
        public FileResult VerifyCodeBuilder()
        {
            string code = Common.Instance.GenCode(5);
            //将验证码加入session中
            HttpContext.Session.SetString("VCode", code);
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
        public IActionResult Login(Models.ApplicationUser model)
        {
            try
            {
                var scode = HttpContext.Session.GetString("VCode").ToLower();
                if (string.Compare(scode, model.VerificyCode) != 0)
                    return Json(new { result = false, message = "验证码错误" });

                var loginer = userService.Single(
                    express: usr => usr.Account == model.Account && usr.Pwd == model.Password,
                    include: src => src.Include(u => u.UserRoles).ThenInclude(r => r.RoleInfomation));

                if (loginer == null)
                    return Json(new { result = false, message = "错误的用户名或密码" });

                //获取用户角色
                string roleCodes = string.Empty;
                loginer.UserRoleDtos.ForEach(x => roleCodes += x.RoleDto.Code + ",");
                roleCodes.Remove(roleCodes.LastIndexOf(','), 1);
                //创建身份证件单元：一张身份证由多个证件单元组成
                //创建身份证件，添加证件单元
                //创建身份证件使用者，添加身份证
                var identitys = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Sid,loginer.ID.ToString()),
                    new Claim(ClaimTypes.Name,model.Account),
                    //new Claim("Password",model.Password),
                    new Claim(ClaimTypes.Role,roleCodes),
                    new Claim(ClaimTypes.UserData,JsonConvert.SerializeObject(loginer.UserRoleDtos))
                });
                //写入客户端cookie
                HttpContext.SignInAsync(identitys.AuthenticationType, new ClaimsPrincipal(identitys), new AuthenticationProperties
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