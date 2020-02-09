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
        public async Task<JsonResult> RemoveAsync(int[] keys)
        {
            return await menuService.RemoveAsync(express:m => keys.Contains(m.ID) ? true : false) ? 
                Json(new { success = true, message = "操作成功！" }) : Json(new { success = false, message = "操作失败！" });
        }

        [HttpPost]
        public async Task<PartialViewResult> EditPartial()
        {
            var result = await menuService.QueryAsync(express: src => (int)src.MenuType > 20 && (int)src.MenuType < 23);
            ViewData["ParentList"] = new SelectList(result.AsEnumerable(), "ID", "Title");
            return PartialView("EditPartial");
        }

        [HttpGet]
        public async Task<JsonResult> PagingAsync(int? offset, int? limit, int? type, string title = null)
        {
            Expression<Func<MenuInfo, bool>> express = inf => true;
            if (type.Value > 0 && !type.HasValue)
                express = inf => express.Compile()(inf) && (int)inf.MenuType == type.Value;
            if (!string.IsNullOrEmpty(title))
                express = inf => express.Compile()(inf) && inf.Title.Contains(title);
            var pageResult = await menuService.QueryAsync(offset.Value, limit.Value, express);
            return Json(pageResult);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }
    }
}