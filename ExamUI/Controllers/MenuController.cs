using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.MenuAgg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        
        [HttpGet]
        public async Task<IActionResult> Lists(int? index = 1, int? size = 10, string type = "", string title = "")
        {
            Expression<Func<MenuInfo, bool>> express = inf => true;
            if (!string.IsNullOrEmpty(type))
                express = inf => express.Compile()(inf) && inf.MenuType.ToString().Contains(type);
            if (!string.IsNullOrEmpty(title))
                express = inf => express.Compile()(inf) && inf.Title.Contains(title);
            var result = await menuService.ListsAsync(index, size, express);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MenuDto model)
        {
            if (model == null)
                return Json(new { success = false, message = "请添加有效数据" });
            return await menuService.SaveAsync(model) ? 
                Json(new { success = true, message = "添加成功" }) : Json(new { success = false, message = "添加失败，请重试" });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MenuDto model)
        {
            return await menuService.EditAsync(model) ? 
                Json(new { success = true, message = "提交成功！" }) : Json(new { success = false, message = "提交失败！" });
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            return await menuService.RemoveAsync(express:m=>m.ID == id) ?
                Json(new { success = true, message = "操作成功！" }) : Json(new { success = false, message = "操作失败！" });
        }

        [HttpGet]
        public async Task<string> ParentsAsync(int? pid = 0)
        {
            var result = await menuService.QuerysAsync(express: m => m.ParentId == pid);
            return JsonConvert.SerializeObject(result);
        }
    }
}