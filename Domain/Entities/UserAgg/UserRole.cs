using Domain.Entities.RoleAgg;

namespace Domain.Entities.UserAgg
{
    public class UserRole : BaseEntity
    {
        public UserRole()
        {
            this.UserInfomation = EntityFactory.Create<UserBase>();
            this.RoleInfomation = EntityFactory.Create<RoleInfo>();
        }
        //导航属性
        public virtual UserBase UserInfomation { get; set; }
        //导航属性
        public virtual RoleInfo RoleInfomation { get; set; }
    }
}
