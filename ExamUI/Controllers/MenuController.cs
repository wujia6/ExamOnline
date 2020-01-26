using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.MenuAgg;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExamUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService service)
        {
            this.menuService = service;
        }
        
        [HttpGet]
        public IActionResult Lists(string type = "", string title = "", int? index = 1, int? size = 10)
        {
            Expression<Func<MenuInfo, bool>> express = null;
            if (!string.IsNullOrEmpty(title) && string.IsNullOrEmpty(type))
                express = m => m.Title == title;
            else if (!string.IsNullOrEmpty(type) && string.IsNullOrEmpty(title))
                express = m => m.MenuType.ToString() == type;
            else if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(type))
                express = m => m.Title == title && m.MenuType.ToString() == type;
            var result = menuService.Lists(out int total, index, size, express);
            return Json(new { total, rows = result });
        }

        [HttpPost]
        public IActionResult Edit(MenuDto model)
        {
            bool isOk = model.ID == 0 ? menuService.Save(model) : menuService.Edit(model);
            return isOk ? Json(new { success = true, message = "提交成功！" }) : Json(new { success = false, message = "提交失败！" });
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            return menuService.Remove(express:m=>m.ID == id) ?
                Json(new { success = true, message = "操作成功！" }) : Json(new { success = false, message = "操作失败！" });
        }

        [HttpGet]
        public async Task<string> ParentsAsync(int? pid = 0)
        {
            var result = await menuService.QueryByAsync(express: m => m.ParentId == pid);
            return JsonConvert.SerializeObject(result);
        }
    }
}