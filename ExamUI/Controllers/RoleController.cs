using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.RoleAgg;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ExamUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        private readonly IMenuService menuService;
        private readonly IMemoryCache appCache;

        public RoleController(IRoleService roleSvr, IMenuService menuSvr, IMemoryCache cache)
        {
            this.roleService = roleSvr ?? throw new ArgumentNullException(nameof(roleService));
            this.menuService = menuSvr ?? throw new ArgumentNullException(nameof(menuService));
            this.appCache = cache ?? throw new ArgumentNullException(nameof(appCache));
        }

        [HttpGet]
        public IActionResult Browse()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> BrowseAsync(int? offset, int? limit, string name = null, string code = null)
        {
            Expression<Func<RoleInfo, bool>> express = null;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(code))
                express = src => src.Name == name && src.Code == code;
            if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(code))
                express = src => src.Name == name;
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(code))
                express = src => src.Code == code;
            var pageResult = await roleService.QueryAsync(
                    offset.Value, 
                    limit.Value, 
                    express, 
                    include: src => src.Include(r => r.RoleAuthorizes).ThenInclude(m => m.PermissionInformation));
            return Json(pageResult);
        }

        [HttpPost]
        public async Task<JsonResult> AddAsync(RoleDto model)
        {
            return await roleService.SaveAsync(model) ? 
                Json(new HttpResult { Success = true, Message = "保存成功" }) : 
                Json(new HttpResult { Success = false, Message = "保存失败，请重试" });
        }

        [HttpPost]
        public async Task<JsonResult> EditAsync(RoleDto model)
        {
            return await roleService.EditAsync(model) ?
                Json(new HttpResult { Success = true, Message = "操作成功" }) : 
                Json(new HttpResult { Success = false, Message = "操作失败，请重试" });
        }

        [HttpPost]
        public async Task<JsonResult> RemoveAsync(int rid)
        {
            return await roleService.RemoveAsync(express:src=>src.ID==rid && src.ID != 1)?
                Json(new HttpResult { Success = true, Message = "操作成功" }) : 
                Json(new HttpResult { Success = false, Message = "操作失败，请重试" });
        }

        [HttpGet]
        public async Task<JsonResult> CompleteMenusAsync()
        {
            if (!(appCache.Get("AllMenus") is List<MenuDto> allMenus) || allMenus.Count == 0)
            {
                allMenus = await menuService.QueryAsync();
                allMenus = GlobalUtils.Recursion(allMenus, 0);
                appCache.Set("AllMenus", allMenus, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),  //设置缓存绝对过期时间
                    Priority = CacheItemPriority.Normal   //设置缓存优先级
                });
            }
            return Json(allMenus);
        }
    }
}