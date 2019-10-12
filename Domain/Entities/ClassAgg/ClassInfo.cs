using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.UserAgg;

namespace Domain.Entities.ClassAgg
{
    /// <summary>
    /// 班级实体类（聚合根）
    /// </summary>
    public class ClassInfo : ClassRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        //public override Guid ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        public ClassGrade Grade { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public ClassCategory Category { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public ClassStatus Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        //public override string Remarks { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IQueryable<ClassExam> ExamInfos { get; set; } = new List<ClassExam>().AsQueryable();

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IQueryable<Student> Students { get; set; } = new List<Student>().AsQueryable();

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IQueryable<ClassTeacher> Teachers { get; set; } = new List<ClassTeacher>().AsQueryable();
    }
}
