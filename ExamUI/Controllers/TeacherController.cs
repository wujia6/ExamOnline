using Application.DTO.Models;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Management(int? pageIndex = 0,int? pageSize = 10)
        {
            var result = userService.Lists(out int total, pageIndex, pageSize);
            return View(result);
        }

        [HttpPost]
        public IActionResult AddOrEdit(TeacherDto model)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            if (id == 0)
                return View("false");
            return View();
        }

        [HttpGet]
        public IActionResult Single(int? teacherId)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lists(int? pageIndex = 0, int? pageSize = 10)
        {
            return View();
        }
    }
}