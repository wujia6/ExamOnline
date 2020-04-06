using System;
using System.Collections.Generic;
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
            ViewData["PermissionType"] = CommonUtils.EnumToSelect(20, 23);
            //var models = GetMemoryCacheList("PermissionAll").Result;
            //models = models.FindAll((PermissionDto dto) => dto.TypeAt != "action");
            //ViewData["PermissionAll"] = CommonUtils.DorpDownInit(models, "Named", "ID");
            return PartialView("EditorPartial");
        }

        [HttpGet]
        public async Task<JsonResult> QueryAsync(string tp = null)
        {
            var models = await GetMemoryCacheList("PermissionAll");
            if (!string.IsNullOrEmpty(tp))
                models = models.FindAll((PermissionDto dto) => dto.TypeAt == CommonUtils.GetCommonEnumName(int.Parse(tp)));
            return Json(models);
        }

        [HttpGet]
        public async Task<JsonResult> PaginatorAsync(int? offset = 0, int? limit = 10, string tp = null, string named = null)
        {
            Expression<Func<PermissionInfo, bool>> exp = null;
            if (!string.IsNullOrEmpty(tp) && string.IsNullOrEmpty(named))
                exp = src => src.TypeAt == int.Parse(tp);
            if (string.IsNullOrEmpty(tp) && !string.IsNullOrEmpty(named))
                exp = src => src.Named == named;
            if (!string.IsNullOrEmpty(tp) && !string.IsNullOrEmpty(named))
                exp = src => src.TypeAt == int.Parse(tp) && src.Named.Contains(named);
            var pageResult = await permissionService.PaginatorAsync(offset.Value, limit.Value, exp);
            return Json(pageResult);
        }

        [HttpGet]
        public IActionResult Browse()
        {
            ViewData["PermissionType"] = CommonUtils.EnumToSelect(20, 23);
            return View();
        }

        /// <summary>
        /// 获取缓存集合
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        private async Task<List<PermissionDto>> GetMemoryCacheList(string cacheKey)
        {
            var models = await cacheUtils.GetCacheAsync(cacheKey, async () =>
            {
                return await permissionService.QueryAsync();
            });
            return models;
        }
    }
}
