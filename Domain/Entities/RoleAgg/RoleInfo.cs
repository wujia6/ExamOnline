using System.Collections.Generic;
using System.Linq;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.Entities.RoleAgg
{
    public class RoleInfo : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public virtual IQueryable<RoleMenu> RoleMenus { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; } 
    }
}
