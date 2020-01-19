using Application.DTO.Models;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService service)
        {
            this.adminService = service;
        }

        [HttpPost]
        public IActionResult AddOrEdit(AdminDto model)
        {
            if (model == null)
                return Json(new { success = false, message = "对象不能为空" });
            return adminService.AddOrEdit(model) ?
                Json(new { success = true, message = "操作成功" }) : Json(new { success = false, message = "操作失败" });
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            return adminService.Remove(express: adm => adm.ID == id) ?
                Json(new { success = true, message = "操作成功" }) : Json(new { success = false, message = "操作失败" });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = adminService.Single(express: adm => adm.ID == id, 
                include: src => src.Include(adm => adm.UserRoles).ThenInclude(r => r.RoleInfomation));
            return View(model);
        }

        [HttpGet]
        public IActionResult Lists(int? pageIndex = 1,int? pageSize = 10)
        {
            var lsts = adminService.Lists(out int total, pageIndex, pageSize);
            ViewBag.AllRecords = total;
            return View(lsts);
        }
    }
}