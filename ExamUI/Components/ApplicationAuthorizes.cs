using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Application.DTO.Models;
using Application.IServices;
using System.Collections.Generic;
using Infrastructure.Utils;

namespace ExamUI.Components
{
    [ViewComponent(Name = "ApplicationAuthorizes")]
    public class ApplicationAuthorizes : ViewComponent
    {
        private readonly IRoleService roleService;
        //private readonly IMemoryCache appCache;
        private readonly CacheUtils appCache;

        public ApplicationAuthorizes(IRoleService service, CacheUtils cache)
        {
            this.roleService = service ?? throw new ArgumentNullException(nameof(roleService));
            this.appCache = cache ?? throw new ArgumentNullException(nameof(appCache));
        }
        
        //此方法由视图组件调用
        public IViewComponentResult Invoke()
        {
            ViewBag.CurrentUser = UserClaimsPrincipal.FindFirstValue(ClaimTypes.Name);
            string roleKeys = UserClaimsPrincipal.FindFirstValue(ClaimTypes.Role);
            //缓存权限集合
            var dtos = appCache.GetOrCreateCache(roleKeys, () =>
            {
                return roleService.SingleAsync(
                    express: inf => inf.Code.Contains(roleKeys),
                    include: inf => inf.Include(r => r.RoleAuthorizes).ThenInclude(p => p.PermissionInformation))
                    .Result
                    .PermssionDtos;
            });
            return View(dtos);
        }
    }
}
