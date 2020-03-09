using System;
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
            this.menuService = service ?? throw new ArgumentNullException(nameof(menuService));
        }

        [HttpPost]
        public async Task<JsonResult> AddAsync(MenuDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
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
            return await menuService.RemoveAsync(express:src => keys.Contains(src.ID) ? true : false) ? 
                Json(new HttpResult { Success = true, Message = "操作成功！" }) : 
                Json(new HttpResult { Success = false, Message = "操作失败！" });
        }

        [HttpPost]
        public async Task<PartialViewResult> EditPartial()
        {
            var result = await menuService.QueryAsync();
            //result.Insert(0, new MenuDto { ID = 0, Title = "--所属父类--" });
            //ViewData["ParentList"] = new SelectList(result.AsEnumerable(), "ID", "Title");
            //ViewData["MenuTypeList"] = GlobalUtils.GetSelectList(20, 23);
            return PartialView("EditPartial");
        }

        [HttpGet]
        public async Task<JsonResult> BrowseAsync(int? offset = 1, int? limit = 10, string tle = null)
        {
            Expression<Func<MenuInfo, bool>> express = null;
            if (!string.IsNullOrEmpty(tle))
                express = src => src.Title.Contains(tle);
            var pageResult = await menuService.QueryAsync(offset.Value, limit.Value, express);
            return Json(pageResult);
        }

        [HttpGet]
        public IActionResult Browse()
        {
            //ViewData["MenuTypeList"] = GlobalUtils.GetSelectList(20, 23);
            return View();
        }
    }
}