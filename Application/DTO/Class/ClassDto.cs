using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTO
{
    public class ClassDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid ID { get; set; }

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
        public string Remarks { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<ClassExamDto> ExamInfos { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<StudentDto> Students { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<ClassTeacherDto> Teachers { get; set; }
    }
}
