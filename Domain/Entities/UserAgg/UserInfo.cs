using System;
using Domain.IComm;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 用户实体类（聚合根）
    /// </summary>
    public abstract class UserInfo : BaseEntity, IAggregateRoot
    {
        public abstract string Account { get; set; }

        public abstract string Pwd { get; set; }

        public abstract string Name { get; set; }

        public abstract Gender Gender { get; set; }

        public abstract int Age { get; set; }

        public abstract string Tel { get; set; }

        public abstract DateTime CreateDate { get; set; }
    }
}
