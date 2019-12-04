using System;
using System.Collections.Generic;
using Domain.IComm;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 用户实体类（聚合根）
    /// </summary>
    public class UserInfo : BaseEntity, IAggregateRoot
    {
        private IEnumerable<UserRole> userRoles;

        public UserInfo() { }

        private UserInfo(Action<object, string> lazy)
        {
            LazyLoader = lazy;
        }

        private Action<object, string> LazyLoader { get; set; }

        //账号
        public string Account { get; set; }

        //密码
        public string Pwd { get; set; }

        //名字
        public string Name { get; set; }

        //性别
        public Gender Gender { get; set; } = Gender.男;

        //年龄
        public int Age { get; set; }

        //电话
        public string Tel { get; set; }

        //创建日期
        public DateTime CreateDate { get; set; }

        //导航属性
        public IEnumerable<UserRole> UserRoles
        {
            get => LazyLoader?.Load(this, ref userRoles);
            set => userRoles = value;
        }
    }
}
