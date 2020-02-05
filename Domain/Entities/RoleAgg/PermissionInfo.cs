using Domain.Entities.MenuAgg;

namespace Domain.Entities.RoleAgg
{
    public class PermissionInfo : BaseEntity
    {
        public string Named { get; set; }

        public string Functional { get; set; }

        public virtual RoleInfo RoleInformation { get; set; }

        public virtual MenuInfo MenuInformation { get; set; }
    }
}
