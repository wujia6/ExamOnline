using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTO
{
    public class StudentDto
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
        /// 学号
        /// </summary>
        public string StudentNo { get; set; }

        /// <summary>
        /// 姓名
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
        /// 身份证
        /// </summary>
        public string IdentityNo { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

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
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ClassDto ClassInfo { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<AnswerDto> AnswerInfos { get; set; }
    }
}
