using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.MenuAgg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ExamUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class MenuController : Controller
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService service)
        {
            this.menuService = service;
        }

        [HttpPost]
        public async Task<JsonResult> AddAsync(MenuDto model)
        {
            if (model == null)
                return Json(new { success = false, message = "请添加有效数据" });
            return await menuService.SaveAsync(model) ? 
                Json(new { success = true, message = "保存成功" }) : Json(new { success = false, message = "保存失败，请重试" });
        }

        [HttpPost]
        public async Task<JsonResult> EditAsync(MenuDto model)
        {
            return await menuService.EditAsync(model) ? 
                Json(new { success = true, message = "保存成功" }) : Json(new { success = false, message = "保存失败，请重试" });
        }

        [HttpPost]
        public async Task<JsonResult> RemoveAsync(int menuId)
        {
            return await menuService.RemoveAsync(express:m => m.ID == menuId) ?
                Json(new { success = true, message = "操作成功！" }) : Json(new { success = false, message = "操作失败！" });
        }

        [HttpGet]
        public async Task<JsonResult> PagingAsync(int? index = 1, int? size = 10, int? type = -1, string title = null)
        {
            Expression<Func<MenuInfo, bool>> express = inf => true;
            if (type.Value > 0 && !type.HasValue)
                express = inf => express.Compile()(inf) && (int)inf.MenuType == type.Value;
            if (!string.IsNullOrEmpty(title))
                express = inf => express.Compile()(inf) && inf.Title.Contains(title);
            var pageResult = await menuService.QueryAsync(index.Value, size.Value, express);
            return Json(pageResult);
        }

        [HttpPost]
        public async Task<JsonResult> GetParentsAsync(int? pid = 0)
        {
            var result = await menuService.QueryAsync(express: m => m.ParentId == pid.Value);
            return result.Count > 0 ?
                Json(new { success = true, rows = result }) : Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public async Task<PartialViewResult> EditPartial()
        {
            var result = await menuService.QueryAsync(express: src => (int)src.MenuType > 20 && (int)src.MenuType < 23);
            ViewData["ParentList"] = new SelectList(result.AsEnumerable(), "ID", "Title");
            return PartialView("EditPartial");
        }
    }
}