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
        public async Task<IActionResult> Lists(int? index = 1, int? size = 10, string type = "", string title = "")
        {
            Expression<Func<MenuInfo, bool>> express = null;
            if (!string.IsNullOrEmpty(title) && string.IsNullOrEmpty(type))
                express = m => m.Title.Contains(title);
            else if (!string.IsNullOrEmpty(type) && string.IsNullOrEmpty(title))
                express = m => m.MenuType.ToString().Contains(title);
            else if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(type))
                express = m => m.Title.Contains(title) && m.MenuType.ToString().Contains(type);
            var result = await menuService.ListsAsync(index, size, express);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Add(MenuDto model)
        {
            if (model == null)
                return Json(new { success = false, message = "请添加有效数据" });
            return menuService.Save(model) ? 
                Json(new { success = true, message = "添加成功" }) : Json(new { success = false, message = "添加失败，请重试" });
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