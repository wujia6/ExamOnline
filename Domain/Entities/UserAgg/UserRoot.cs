using System;
using Domain.IComm;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 用户实体类（聚合根）
    /// </summary>
    public abstract class UserRoot : BaseEntity, IAggregateRoot
    {
        public string Account { get; set; }
        
        public string Pwd { get; set; }
        
        public string Name { get; set; }
        
        public Gender Gender { get; set; } = Gender.男;
        
        public int Age { get; set; }
        
        public string Tel { get; set; }
        
        public DateTime CreateDate { get; set; }
    }
}
