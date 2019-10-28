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

        [HttpPost]
        public IActionResult Login(UserDTO model)
        {
            //if (!ModelState.IsValid)
            //{
            //    foreach (var key in ModelState.Keys)
            //    {
            //        var modelState = ModelState[key];
            //        if (modelState.Errors.Any())
            //            return Content(modelState.Errors.FirstOrDefault().ErrorMessage);
            //    }
            //}
            //var loginDto = model.MapTo<UserRootDTO>();
            //var loginer = userService.UserLogin(loginDto);
            return View();
        }

        [HttpPost]
        public IActionResult Register()
        {
            return View();
        }
    }
}