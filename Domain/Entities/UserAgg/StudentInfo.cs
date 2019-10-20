using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 学生实体类
    /// </summary>
    public class StudentInfo : UserRoot
    {
        /// <summary>
        /// 学号
        /// </summary>
        public string StudentNo { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IdentityNo { get; set; }

        /// <summary>
        /// 监护人电话
        /// </summary>
        public string ParentTel { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 寝室号
        /// </summary>
        public string Dormitory { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual ClassInfo ClassInfomation { get; set; } = EntityFactory.Create<ClassInfo>();

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IQueryable<AnswerInfo> AnswerInfomations { get; set; }
    }
}
