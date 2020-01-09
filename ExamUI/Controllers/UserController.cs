using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamUI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles ="admin,teacher")]
        public IActionResult TeacherManage()
        {

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin,teacher,student")]
        public IActionResult StudentManage()
        {
            return View();
        }
    }
}