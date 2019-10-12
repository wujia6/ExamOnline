using System;
using System.Linq;
using Domain.Entities.ClassAgg;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 学生实体类
    /// </summary>
    public class Student : UserInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        //public override Guid ID { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        //public override string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        //public override string Pwd { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        public string StudentNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        //public override string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        //public override Gender Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        //public override int Age { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IdentityNo { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        //public override string Tel { get; set; }

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
        /// 创建时间
        /// </summary>
        //public override DateTime CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 备注
        /// </summary>
        //public override string Remarks { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual ClassInfo ClassInfo { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IQueryable<AnwserAgg.AnswerInfo> AnswerInfos { get; set; }
    }
}
