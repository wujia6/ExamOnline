using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.UserAgg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamUI.Controllers
{
    [Authorize(Roles = "admin,teacher")]
    public class TeacherController : Controller
    {
        private readonly IUserService userService;
        private readonly IClassService classService;

        public TeacherController(IUserService usr, IClassService cls)
        {
            this.userService = usr;
            this.classService = cls;
        }
    }
}