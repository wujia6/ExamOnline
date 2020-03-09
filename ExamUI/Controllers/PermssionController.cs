using System;
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
    public class PermssionController : Controller
    {
        private readonly IPermssionService permissionService;

        public PermssionController(IPermssionService service)
        {
            this.permissionService = service ?? throw new ArgumentNullException(nameof(service));
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
        public async Task<JsonResult> BrowseAsync(int? offset = 1,int? limit = 10, string tp = null)
        {
            Expression<Func<PermissionInfo, bool>> express = null;
            if (!string.IsNullOrEmpty(tp))
                express = p => GlobalUtils.GetApplicationTypeName(p.TypeAt) == tp;
            var pageResult = await permissionService.QueryAsync(offset, limit, express);
            return Json(pageResult);
        }

        [HttpGet]
        public IActionResult Browse()
        {
            return View();
        }
    }
}
