using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
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
using Application.DTO.Models;

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
        public FileResult CodeBuilder()
        {
            string code = GenCode(5);
            var bytes = ImageBuilder(code);
            HttpContext.Session.SetString("VCode", code);   //将验证码加入session中
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
        public async Task<IActionResult> Login(ApplicationUser model)
        {
            try
            {
                var scode = HttpContext.Session.GetString("VCode").ToLower();
                if (string.Compare(scode, model.VerificyCode) != 0)
                    return Json(new { success = false, message = "验证码错误" });

                var applicationUser = userService.Single(
                    express: usr => usr.Account == model.UserAccount && usr.Pwd == model.UserPassword,
                    include: src => src.Include(u => u.UserRoles).ThenInclude(r => r.RoleInfomation));

                if (applicationUser == null)
                    return Json(new { success = false, message = "错误的用户名或密码" });

                //创建身份证件单元：一张身份证由多个证件单元组成
                //创建身份证件，添加证件单元
                //创建身份证件使用者，添加身份证
                var identitys = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Sid,applicationUser.UserID.ToString()),
                    new Claim(ClaimTypes.NameIdentifier,applicationUser.UserAccount),
                    new Claim(ClaimTypes.Role,applicationUser.InRoles),
                    new Claim(ClaimTypes.Name,applicationUser.Name)
                    //new Claim("Password",model.Password),
                    //new Claim(ClaimTypes.UserData,JsonConvert.SerializeObject(applicationUser))
                });
                //写入客户端cookie
                await HttpContext.SignInAsync(identitys.AuthenticationType, new ClaimsPrincipal(identitys), new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(model.ExpireMin),
                    IsPersistent = true,
                    AllowRefresh = true
                });
                return Json(new { success = true, message = "登录成功", path = "/Home/Index" });
            }
            catch (Exception ex)
            {
                //return LocalRedirect("~/Views/Shared/Error.cshtml");
                throw ex;
            }
        }

        #region ### 私有成员方法
        /// <summary>
        /// 产生图片验证码
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        private byte[] ImageBuilder(string code)
        {
            Bitmap image = new Bitmap(70, 22);
            Graphics gdi = Graphics.FromImage(image);
            try
            {
                //生成随机生成器  
                Random random = new Random();
                //清空图片背景色  
                gdi.Clear(Color.White);
                // 画图片的背景噪音线  
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    gdi.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                Font font = new Font("Arial", 12, (FontStyle.Bold));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2F, true);
                gdi.DrawString(code, font, brush, 2, 2);
                //画图片的前景噪音点  
                gdi.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
            finally
            {
                gdi.Dispose();
                image.Dispose();
            }
        }

        /// <summary>  
        /// 产生随机字符串  
        /// </summary>  
        /// <param name="num">随机出几个字符</param>  
        /// <returns>随机出的字符串</returns>  
        private string GenCode(int num)
        {
            string str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] chastr = str.ToCharArray();
            string code = string.Empty;
            Random rd = new Random();
            for (int i = 0; i < num; i++)
            {
                code += str.Substring(rd.Next(0, str.Length), 1);
            }
            return code;
        }
        #endregion
    }
}