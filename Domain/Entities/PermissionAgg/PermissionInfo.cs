using System.Collections.Generic;
using Domain.Entities.RoleAgg;
using Domain.IComm;

namespace Domain.Entities.PermissionAgg
{
    public class PermissionInfo : BaseEntity, IAggregateRoot
    {
        //层级ID
        public int LevelID { get; set; }
        //类型
        public int TypeAt { get; set; }
        //命名
        public string Named { get; set; }
        //命令
        public string Command { get; set; }
        //导航属性
        public IEnumerable<RoleAuthorize> RoleAuthorizes { get; set; }
    }
}
