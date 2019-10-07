using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTO
{
    public class TeacherDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

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
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<ClassTeacherDTO> Classes { get; set; }
    }
}
