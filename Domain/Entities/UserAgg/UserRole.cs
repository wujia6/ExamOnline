using Domain.Entities.RoleAgg;

namespace Domain.Entities.UserAgg
{
    public class UserRole : BaseEntity
    {
        //public UserRole()
        //{
        //    this.UserInfomation = EntityFactory.Create<UserInfo>();
        //    this.RoleInfomation = EntityFactory.Create<RoleInfo>();
        //}
        //导航属性
        public virtual UserInfo UserInfomation { get; set; }
        //导航属性
        public virtual RoleInfo RoleInfomation { get; set; }
    }
}
