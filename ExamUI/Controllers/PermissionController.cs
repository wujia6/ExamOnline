using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public async Task<JsonResult> SingleAsync(int id, int? lid, int? tpid)
        {
            Expression<Func<PermissionInfo, bool>> express = src => src.ID == id;
            if (lid.HasValue)
                express = src => express.Compile()(src) && src.LevelID == lid;
            if (tpid.HasValue)
                express = src => express.Compile()(src) && src.TypeAt == tpid;
            var model = await permissionService.SingleAsync(express);
            return Json(model);
        }

        [HttpGet]
        public async Task<JsonResult> SearchAsync(int? id, int? lid, int? tpid)
        {
            Expression<Func<PermissionInfo, bool>> express = src => true;
            if (id.HasValue)
                express = src => express.Compile()(src) && src.ID == id;
            if (lid.HasValue)
                express = src => express.Compile()(src) && src.LevelID == lid;
            if (tpid.HasValue)
                express = src => express.Compile()(src) && src.TypeAt == tpid;
            var models = await permissionService.QueryAsync(express);
            return Json(models);
        }

        [HttpGet]
        public async Task<JsonResult> PaginatorAsync(int? offset = 0, int? limit = 10, string tp = null)
        {
            Expression<Func<PermissionInfo, bool>> express = src => true;
            if (!string.IsNullOrEmpty(tp))
                express = src => express.Compile()(src) && src.TypeAt == int.Parse(tp);
            var pageResult = await permissionService.PaginatorAsync(offset.Value, limit.Value, express);
            return Json(pageResult);
        }

        [HttpGet]
        public IActionResult Browse()
        {
            ViewData["PermissionType"] = CommonUtils.GetSelectList(20, 23);
            return View();
        }

        [HttpPost]
        public PartialViewResult EditorPartial()
        {
            return PartialView("EditorPartial");
        }

        [HttpGet]
        public async Task<JsonResult> GetPermissionAllAsync()
        {
            //var models = await cacheUtils.GetCacheAsync("ApplicationPermissions", async () =>
            //{
            //    return await permissionService.QueryAsync();
            //});
            var models = await permissionService.QueryAsync();
            return Json(models);
        }
    }
}
