﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.PermissionAgg;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class PermissionController : Controller
    {
        private readonly IPermssionService permissionService;
        private readonly CacheUtils cacheUtils;

        public PermissionController(IPermssionService service, CacheUtils cache)
        {
            this.permissionService = service ?? throw new ArgumentNullException(nameof(service));
            this.cacheUtils = cache ?? throw new ArgumentNullException(nameof(cacheUtils));
        }

        [HttpPost]
        public async Task<JsonResult> AddAsync(PermissionDto model)
        {
            if (model==null)
                throw new ArgumentNullException(nameof(model));
            return await permissionService.SaveAsync(model) ?
                Json(new HttpResult { Success = true, Message = "保存成功" }) : 
                Json(new HttpResult { Success = false, Message = "保存失败" });
        }

        [HttpPost]
        public async Task<JsonResult> RemoveAsync(int? id)
        {
            if (!id.HasValue)
                throw new ArgumentNullException("id","参数id为空");
            return await permissionService.RemoveAsync(express: p => p.ID == id || p.LevelID == id) ?
                Json(new HttpResult { Success = true, Message = "操作成功" }) :
                Json(new HttpResult { Success = false, Message = "操作失败" });
        }

        [HttpPost]
        public async Task<JsonResult> EditAsync(PermissionDto model)
        {
            if (model==null)
                throw new ArgumentNullException(nameof(model));
            return await permissionService.EditAsync(model) ?
                Json(new HttpResult { Success = true, Message = "操作成功" }) :
                Json(new HttpResult { Success = false, Message = "操作失败" });
        }

        [HttpPost]
        public PartialViewResult EditorPartial()
        {
            ViewData["PermissionType"] = CommonUtils.GetSelectList(20, 23);
            return PartialView("EditorPartial");
        }

        [HttpGet]
        public async Task<JsonResult> QueryAsync(string tp = null)
        {
            var models = await cacheUtils.GetCacheAsync("ApplicationPermissions", async () =>
            {
                return await permissionService.QueryAsync();
            });

            if (models == null || models.Count == 0)
                return Json(new { Success = false, Message = "数据源获取失败" });
            else if (!string.IsNullOrEmpty(tp))
                models = models.FindAll((PermissionDto dto) => dto.TypeAt == CommonUtils.GetCommonEnumName(int.Parse(tp)));
            return Json(models);
        }

        [HttpGet]
        public async Task<JsonResult> PaginatorAsync(int? offset = 0, int? limit = 10, string tpid = null, string named = null)
        {
            Expression<Func<PermissionInfo, bool>> express = null;
            if (!string.IsNullOrEmpty(tpid) && string.IsNullOrEmpty(named))
                express = src => src.TypeAt == int.Parse(tpid);
            if (string.IsNullOrEmpty(tpid) && !string.IsNullOrEmpty(named))
                express = src => src.Named == named;
            if (!string.IsNullOrEmpty(tpid) && !string.IsNullOrEmpty(named))
                express = src => src.TypeAt == int.Parse(tpid) && src.Named.Contains(named);
            var pageResult = await permissionService.PaginatorAsync(offset.Value, limit.Value, express);
            return Json(pageResult);
        }

        [HttpGet]
        public IActionResult Browse()
        {
            ViewData["PermissionType"] = CommonUtils.GetSelectList(20, 23);
            return View();
        }

        //[HttpGet]
        //public async Task<JsonResult> SingleAsync(int id, int? lid, int? tpid)
        //{
        //    Expression<Func<PermissionInfo, bool>> express = src => src.ID == id;
        //    if (lid.HasValue)
        //        express = src => express.Compile()(src) && src.LevelID == lid;
        //    if (tpid.HasValue)
        //        express = src => express.Compile()(src) && src.TypeAt == tpid;
        //    var model = await permissionService.SingleAsync(express);
        //    return Json(model);
        //}

        //[HttpGet]
        //public async Task<JsonResult> GetPermissionAllAsync()
        //{
        //    var models = await cacheUtils.GetCacheAsync("ApplicationPermissions", async () =>
        //    {
        //        return await permissionService.QueryAsync();
        //    });
        //    //var models = await permissionService.QueryAsync();
        //    return Json(models);
        //}
    }
}
