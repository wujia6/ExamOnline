using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.RoleAgg;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService service)
        {
            this.roleService = service ?? throw new ArgumentNullException(nameof(roleService));
        }

        [HttpGet]
        public IActionResult Manage()
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
            var pageResult = await roleService.QueryAsync(offset.Value, limit.Value, express, include: src => src.Include(rms => rms.RoleMenus));
            return Json(pageResult);
        }

        [HttpPost]
        public async Task<JsonResult> AddAsync(RoleDto model)
        {
            return await roleService.SaveAsync(model) ? 
                Json(new HttpResult { Success = true, Message = "保存成功" }) : Json(new HttpResult { Success = false, Message = "保存失败，请重试" });
        }

        [HttpPost]
        public async Task<JsonResult> EditAsync(RoleDto model)
        {
            return await roleService.EditAsync(model) ?
                Json(new HttpResult { Success = true, Message = "操作成功" }) : Json(new HttpResult { Success = false, Message = "操作失败，请重试" });
        }

        [HttpPost]
        public async Task<JsonResult> RemoveAsync(int rid)
        {
            return await roleService.RemoveAsync(express:src=>src.ID==rid && src.ID != 1)?
                Json(new HttpResult { Success = true, Message = "操作成功" }) : Json(new HttpResult { Success = false, Message = "操作失败，请重试" });
        }
    }
}