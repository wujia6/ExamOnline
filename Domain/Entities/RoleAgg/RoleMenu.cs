using Domain.Entities.MenuAgg;

namespace Domain.Entities.RoleAgg
{
    public class RoleMenu : BaseEntity
    {
        public RoleMenu()
        {
            RoleInfomation = EntityFactory.Create<RoleInfo>();
            MenuInfomation = EntityFactory.Create<MenuInfo>();
        }

        //导航属性
        public virtual RoleInfo RoleInfomation { get; set; }
        //导航属性
        public virtual MenuInfo MenuInfomation { get; set; }
    }
}
