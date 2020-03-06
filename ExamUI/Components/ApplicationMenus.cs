using System;
using System.Collections.Generic;
using System.Security.Claims;
using Application.DTO.Models;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ExamUI.Components
{
    /// <summary>
    /// 系统菜单视图组件类
    /// </summary>
    [ViewComponent(Name = "ApplicationMenus")]
    public class ApplicationMenus : ViewComponent
    {
        private readonly IMenuService menuSvr;
        private readonly IMemoryCache appCache;

        public ApplicationMenus(IMenuService service, IMemoryCache cache)
        {
            this.menuSvr = service ?? throw new ArgumentNullException(nameof(menuSvr));
            this.appCache = cache ?? throw new ArgumentNullException(nameof(appCache));
        }
        
        public IViewComponentResult Invoke()
        {
            //缓存菜单
            if (!(appCache.Get("ApplicationMenus") is List<MenuDto> appMenus))
            {
                appMenus = menuSvr.QueryAsync().Result;
                appCache.Set("ApplicationMenus", appMenus, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),  //设置缓存绝对过期时间
                    Priority = CacheItemPriority.Normal   //设置缓存优先级
                });
            }
            return View(appMenus);
        }
    }
}
