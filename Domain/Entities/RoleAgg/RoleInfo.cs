using System;
using System.Collections.Generic;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.Entities.RoleAgg
{
    public class RoleInfo : BaseEntity, IAggregateRoot
    {
        private IEnumerable<RoleMenu> roleMenus;

        public RoleInfo() { }

        private RoleInfo(Action<object,string> lazy)
        {
            LazyLoader = lazy;
        }

        private Action<object,string> LazyLoader { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        //导航属性
        public IEnumerable<RoleMenu> RoleMenus
        {
            get => LazyLoader?.Load(this, ref roleMenus);
            set => roleMenus = value;
        }
        //导航属性
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
