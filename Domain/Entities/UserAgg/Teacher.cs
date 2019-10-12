using System;
using System.Linq;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 教师实体类
    /// </summary>
    public class Teacher : UserInfo
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
        /// 名称
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
        /// 电话
        /// </summary>
        //public override string Tel { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Profssion { get; set; }

        /// <summary>
        /// 课程
        /// </summary>
        public Subject Course { get; set; }

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
        public virtual IQueryable<ClassAgg.ClassTeacher> Classes { get; set; }
    }
}
