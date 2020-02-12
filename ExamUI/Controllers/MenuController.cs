﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.Utils;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.MenuAgg;

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
                return Json(new HttpResult { Success = false, Message = "请添加有效数据" });
            return await menuService.SaveAsync(model) ? 
                Json(new HttpResult{ Success = true, Message = "保存成功" }) : 
                Json(new HttpResult { Success = false, Message = "保存失败，请重试" });
        }

        [HttpPost]
        public async Task<JsonResult> EditAsync(MenuDto model)
        {
            return await menuService.EditAsync(model) ? 
                Json(new HttpResult { Success = true, Message = "保存成功" }) : 
                Json(new HttpResult { Success = false, Message = "保存失败，请重试" });
        }

        [HttpPost]
        public async Task<JsonResult> RemoveAsync(int[] keys)
        {
            return await menuService.RemoveAsync(express:m => keys.Contains(m.ID) ? true : false) ? 
                Json(new HttpResult { Success = true, Message = "操作成功！" }) : 
                Json(new HttpResult { Success = false, Message = "操作失败！" });
        }

        [HttpPost]
        public async Task<PartialViewResult> EditPartial()
        {
            var result = await menuService.QueryAsync(express: src => (int)src.MenuType > 20 && (int)src.MenuType < 23);
            result.Insert(0, new MenuDto { ID = 0, Title = "--所有父类--" });
            ViewData["ParentList"] = new SelectList(result.AsEnumerable(), "ID", "Title");
            return PartialView("EditPartial");
        }

        [HttpGet]
        public async Task<JsonResult> PagingAsync(int? offset, int? limit, int? type, string title = null)
        {
            Expression<Func<MenuInfo, bool>> express = inf => true;
            if (type.Value > 0)
                express = inf => express.Compile()(inf) && (int)inf.MenuType == type.Value;
            if (!string.IsNullOrEmpty(title))
                express = inf => express.Compile()(inf) && inf.Title.Contains(title);
            var pageResult = await menuService.QueryAsync(offset.Value, limit.Value, express);
            return Json(pageResult);
        }

        [HttpPost]
        public IActionResult EditTo(MenuDto model)
        {
            return menuService.EditTo(model) ?
                Json(new HttpResult { Success = true, Message = "操作成功" }) :
                Json(new HttpResult { Success = false, Message = "操作失败，请重试" });
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }
    }
}