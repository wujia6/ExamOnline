using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.ExamAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.Entities.ClassAgg
{
    /// <summary>
    /// 班级实体类（聚合根）
    /// </summary>
    public class ClassInfo : BaseEntity, IAggregateRoot
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
        public virtual IEnumerable<ClassExamination> ClassExams { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IEnumerable<StudentInfo> StudentInfomations { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IEnumerable<ClassTeacher> ClassTeachers { get; set; }

        /// <summary>
        /// 获取班级老师集合
        /// </summary>
        /// <returns></returns>
        //public IEnumerable<TeacherInfo> GetTeachers()
        //{
        //    if (ClassTeachers == null || ClassTeachers.ToList().Count == 0)
        //        return null;
        //    return ClassTeachers.Select(t => t.TeacherInfomation);
        //}

        /// <summary>
        /// 获取班级参考信息集合
        /// </summary>
        /// <returns></returns>
        //public IEnumerable<ExaminationInfo> GetExaminations()
        //{
        //    if (ClassExams == null || ClassExams.ToList().Count == 0)
        //        return null;
        //    return ClassExams.Select(x => x.ExamInfomation);
        //}
    }
}
