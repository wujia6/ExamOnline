﻿using System.Collections.Generic;
using Domain.Entities.RoleAgg;
using Domain.IComm;

namespace Domain.Entities.MenuAgg
{
    /// <summary>
    /// 菜单聚合类Universal
    /// </summary>
    public class MenuInfo : BaseEntity, IAggregateRoot
    {
        //父ID
        //public int ParentId { get; set; }

        //类型
        //public int MenuType { get; set; }

        //标题
        public string Title { get; set; }

        //路径
        public string PathUrl { get; set; }

        //启用
        public bool Enabled { get; set; }

        //控制器名称
        //public string Controller { get; set; }

        //菜单代码
        //public string Action { get; set; }

        //导航属性
        //public virtual IEnumerable<RoleMenu> RoleMenus { get; set; }
    }
}
