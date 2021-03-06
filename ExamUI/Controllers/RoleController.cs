﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.RoleAgg;
using Infrastructure.Utils;

namespace ExamUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        private readonly CacheUtils cacheUtils;

        public RoleController(IRoleService _roleService, CacheUtils cache)
        {
            this.roleService = _roleService ?? throw new ArgumentNullException(nameof(roleService));
            this.cacheUtils = cache ?? throw new ArgumentNullException(nameof(cacheUtils));
        }

        [HttpGet]
        public IActionResult Browse()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult EditForm()
        {
            return PartialView("EditForm");
        }

        [HttpGet]
        public async Task<JsonResult> PaginatorAsync(int? offset = 0, int? limit = 10, string name = null, string code = null)
        {
            Expression<Func<RoleInfo, bool>> exp = null;
            if (!string.IsNullOrEmpty(name))
                exp = src => src.Name.Contains(name);
            if (!string.IsNullOrEmpty(code))
                exp = src => src.Code.Contains(code);
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(code))
                exp = src => src.Name.Contains(name) && src.Code.Contains(code);
            var pageResult = await roleService.QueryAsync(offset.Value, limit.Value, exp);
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
            return await roleService.RemoveAsync(express: src => src.ID == rid && src.ID != 1) ?
                Json(new HttpResult { Success = true, Message = "操作成功" }) :
                Json(new HttpResult { Success = false, Message = "操作失败，请重试" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthorizesByRole(string code)
        {
            //var result = await Task.Run(async ()=> { });
            //获取角色授权
            //var model = await roleService.SingleAsync(
            //        express: src => src.Code.Contains(code),
            //        include: src => src.Include(inf => inf.RoleAuthorizes).ThenInclude(p => p.PermissionInformation));
            ////ViewBag.SelectedRole = JsonConvert.SerializeObject(model.PermssionDtos);
            //return Json(model.PermssionDtos);
            //var roleCode = User.FindFirstValue(ClaimTypes.Role);
            var dtoResult = await cacheUtils.GetCacheAsync(code, async () =>
            {
                var model = await roleService.SingleAsync(
                express: src => src.Code.Contains(code),
                include: src => src.Include(inf => inf.RoleAuthorizes).ThenInclude(p => p.PermissionInformation));
                return model.PermssionDtos;
            });
            return Json(dtoResult);
        }
    }
}