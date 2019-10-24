using Domain.Entities.RoleAgg;

namespace Domain.Entities.UserAgg
{
    public class UserRole : BaseEntity
    {
        public virtual UserRoot UserInfomation { get; set; }

        public virtual RoleInfo RoleInfomation { get; set; }
    }
}
