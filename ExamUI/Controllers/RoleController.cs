using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Security.Claims;
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
            Expression<Func<RoleInfo, bool>> express = src => true;
            if (!string.IsNullOrEmpty(name))
                express = src => express.Compile()(src) && src.Name.Contains(name);
            if (!string.IsNullOrEmpty(code))
                express = src => express.Compile()(src) && src.Code.Contains(code);
            var pageResult = await roleService.QueryAsync(offset.Value, limit.Value);
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
        public async Task<JsonResult> GetAuthorizesByRole(string code)
        {
            //var result = await Task.Run(async ()=> { });
            var roleCode = User.FindFirstValue(ClaimTypes.Role);
            //获取角色授权
            var authorizesDtos = await cacheUtils.GetCacheAsync(roleCode, async () =>
            {
                var model = await roleService.SingleAsync(
                express: src => src.Code.Contains(code),
                include: src => src.Include(inf => inf.RoleAuthorizes).ThenInclude(p => p.PermissionInformation));
                return model.PermssionDtos;
            });
            return Json(authorizesDtos);
        }
    }
}