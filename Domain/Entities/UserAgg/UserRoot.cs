using System;
using System.Linq;
using Domain.Entities.RoleAgg;
using Domain.IComm;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 用户实体类（聚合根）
    /// </summary>
    public abstract class UserRoot : BaseEntity, IAggregateRoot
    {
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
        public virtual IQueryable<UserRole> UserRoles { get; set; }
    }
}
