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
    }
}