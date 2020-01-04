using System.Collections.Generic;
using System.Linq;
using Domain.Entities.MenuAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.Entities.RoleAgg
{
    public class RoleInfo : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public string Code { get; set; }

        //导航属性
        public virtual IEnumerable<RoleMenu> RoleMenus { get; set; }

        //导航属性
        public virtual IEnumerable<UserRole> UserRoles { get; set; }

        /// <summary>
        /// 获取角色菜单
        /// </summary>
        /// <returns></returns>
        public List<MenuInfo> GetMenus()
        {
            if (RoleMenus.ToList().Count == 0)
                return null;
            return RoleMenus.Where(x => x.RoleInfomation.Code == this.Code).Select(m => m.MenuInfomation).ToList();
        }

        /// <summary>
        /// 获取该角色所有用户
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserInfo> GetUsers()
        {
            if (UserRoles == null || UserRoles.ToList().Count == 0)
                return null;
            return UserRoles.Select(x => x.UserInfomation);
        }
    }
}
