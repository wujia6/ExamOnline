using System;
using Domain.Entities.RoleAgg;

namespace Domain.Entities.UserAgg
{
    public class UserRole : BaseEntity
    {
        private UserInfo userInfomation;
        private RoleInfo roleInfomation;

        public UserRole() { }

        private UserRole(Action<object,string> lazy)
        {
            this.LazyLoader = lazy;
        }

        private Action<object, string> LazyLoader { get; set; }

        //导航属性
        public UserInfo UserInfomation
        {
            get => LazyLoader?.Load(this, ref userInfomation);
            set => userInfomation = value;
        }

        //导航属性
        public RoleInfo RoleInfomation
        {
            get => LazyLoader?.Load(this, ref roleInfomation);
            set => roleInfomation = value;
        }
    }
}
