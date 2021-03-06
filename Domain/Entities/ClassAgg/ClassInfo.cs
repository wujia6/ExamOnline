﻿using System;
using System.Collections.Generic;
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
        public int Grade { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public int Category { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

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
    }
}
