using System;
using System.Runtime.Serialization;
using Domain.IComm;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 用户实体类（聚合根）
    /// </summary>
    public abstract class UserRoot : BaseEntity, IAggregateRoot
    {
        [DataMember]
        public string Account { get; set; }

        [DataMember]
        public string Pwd { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Gender Gender { get; set; } = Gender.男;

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string Tel { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }
    }
}
