using Domain.Entities.PermissionAgg;

namespace Domain.Entities.RoleAgg
{
    public class RoleAuthorize : BaseEntity
    {
        public virtual RoleInfo RoleInformation { get; set; }

        public virtual PermissionInfo PermissionInformation { get; set; }
    }
}
