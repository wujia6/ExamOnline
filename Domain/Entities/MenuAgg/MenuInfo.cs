using System.Linq;
using Domain.Entities.RoleAgg;
using Domain.IComm;

namespace Domain.Entities.MenuAgg
{
    /// <summary>
    /// 菜单聚合类
    /// </summary>
    public class MenuInfo : BaseEntity, IAggregateRoot
    {
        //父ID
        public int ParentId { get; set; }
        //菜单类型
        public CommType MenuType { get; set; } = CommType.menu;
        //菜单标题
        public string Title { get; set; }
        //菜单代码
        public string Code { get; set; }
        //菜单路径
        public string Url { get; set; }
        //导航属性
        public virtual IQueryable<RoleMenu> RoleMenus { get; set; }
    }
}
