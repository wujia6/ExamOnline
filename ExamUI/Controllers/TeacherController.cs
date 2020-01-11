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

        [HttpPost]
        public IActionResult AddOrEdit(TeacherDto model)
        {
            if (model == null)
                return Json(new { success = false, message = "目标不能为空" });

            return userService.AddOrEdit(model) ? 
                Json(new { success = true, message = "操作成功！" }) : Json(new { success = false, message = "操作失败！" });
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            if (id == 0)
                return Json(new { success = false, message = "请选择删除记录" });
            return userService.Remove(express:t=>t.ID==id)?
                Json(new { success = true, message = "删除成功！" }) : Json(new { success = false, message = "删除失败！" });
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var model = userService.Single(express: t => t.ID == id,
                include: src => src.Include(x => (x as TeacherInfo).ClassTeachers).ThenInclude(ct => ct.ClassInfomation));
            return View(model);
        }

        [HttpGet]
        public IActionResult Lists(int? pageIndex = 0, int? pageSize = 10)
        {
            var lsts = userService.Lists(out int total, pageIndex, pageSize);
            return Json(new { total, result = lsts });
        }
    }
}