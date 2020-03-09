using System.Collections.Generic;
using Domain.Entities.RoleAgg;
using Domain.IComm;

namespace Domain.Entities.MenuAgg
{
    /// <summary>
    /// 菜单聚合类Universal
    /// </summary>
    public class MenuInfo : BaseEntity, IAggregateRoot
    {
        //标题
        public string Title { get; set; }

        //路径
        public string PathUrl { get; set; }

        //启用
        public bool Enabled { get; set; }
    }
}
