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
using Application.DTO;
using Domain.Entities;
using System.Collections.Generic;

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
                    return Json(new { result = false, message = "格式错误，请重新检查格式" });

                //var userInfo = userService.FindBy(express: usr => usr.Account == model.Account && usr.Pwd == model.Password);
                var userInfo = new UserDTO
                {
                    ID = 1,
                    Account = "admin1",
                    Pwd = "a1234567",
                    Name = "吴嘉",
                    Gender = Gender.男,
                    Age = 38,
                    Tel = "18673968186",
                    CreateDate = DateTime.Now,
                    Remarks = "暂无",
                    UserRoleDtos = new List<UserRoleDTO> { new UserRoleDTO
                    {
                        ID = 1,
                        RoleDto = new RoleDTO { ID = 1, Name = "admin" }
                    }}
                };

                if (userInfo == null)
                    return Json(new { result = false, message = "错误的账号或密码" });

                //var identity = new CustomIdentity(new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(userInfo)));
                //var principal = new ClaimsPrincipal(identity);
                //获取用户角色集合
                //string roles = string.Empty;
                //userInfo.UserRoleDtos.ForEach(x => roles += x.RoleDto.ID + ",");
                //roles.Remove(-1, 1);
                //创建身份证件单元：一张身份证由许多证件单元组成
                //创建身份证件，添加证件单元
                //创建身份证件使用者，添加身份证
                var identity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Sid,userInfo.ID.ToString()),
                    new Claim(ClaimTypes.Name,model.Account),
                    new Claim("password",model.Password),
                    new Claim(ClaimTypes.Role,userInfo.UserRoleDtos[0].RoleDto.Name),
                    new Claim(ClaimTypes.UserData,JsonConvert.SerializeObject(userInfo.UserRoleDtos))
                });
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(model.ExpireMin),
                    IsPersistent = true,
                    AllowRefresh = true
                });
                return Json(new { result = true, message = "登录成功", url = "/Home/Index" });
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