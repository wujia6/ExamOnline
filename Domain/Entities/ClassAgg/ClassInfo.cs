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
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        public ClassGrade Grade { get; set; } = ClassGrade.一年级;

        /// <summary>
        /// 类别
        /// </summary>
        public CommType Category { get; set; } = CommType.专业班;

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 状态
        /// </summary>
        public ClassStatus Status { get; set; } = ClassStatus.未启用;

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IQueryable<ClassExam> ClassExams { get; set; } = new List<ClassExam>().AsQueryable();

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IQueryable<StudentInfo> StudentInfomations { get; set; } = new List<StudentInfo>().AsQueryable();

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IQueryable<ClassTeacher> ClassTeachers { get; set; } = new List<ClassTeacher>().AsQueryable();
    }
}
