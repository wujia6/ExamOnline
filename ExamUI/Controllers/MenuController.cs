using System;
using System.Linq.Expressions;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.MenuAgg;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Lists(string name = null, string tp = null, int? pageIndex = 1, int? pageSize = 10)
        {
            Expression<Func<MenuInfo, bool>> express = null;
            if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(tp))
                express = m => m.Title == name;
            else if (!string.IsNullOrEmpty(tp) && string.IsNullOrEmpty(name))
                express = m => m.MenuType.ToString() == tp;
            else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(tp))
                express = m => m.Title == name && m.MenuType.ToString() == tp;
            var result = menuService.Lists(out int total, pageIndex, pageSize, express);
            return Json(new { index = pageIndex, size = pageSize, sum=total/pageSize, rows = result });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var dto = menuService.FindBy(express: m => m.ID == id);
            return Json(dto);
        }

        [HttpPost]
        public IActionResult Edit(MenuDto model)
        {
            return menuService.AddOrEdit(model) ?
                Json(new { success = true, message = "操作成功！" }) : Json(new { success = false, message = "操作失败！" });
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            return menuService.Remove(express:m=>m.ID==id) ?
                Json(new { success = true, message = "操作成功！" }) : Json(new { success = false, message = "操作失败！" });
        }
    }
}