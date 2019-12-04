using System.Collections.Generic;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.Entities.RoleAgg
{
    public class RoleInfo : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public virtual IEnumerable<RoleMenu> RoleMenus { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }
}
