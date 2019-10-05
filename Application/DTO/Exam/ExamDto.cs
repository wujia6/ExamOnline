using System;
using System.Collections.Generic;

namespace Application.DTO
{
    public class ExamDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 监考老师（导航属性）
        /// </summary>
        public ICollection<TeacherDto> Teachers { get; set; }

        /// <summary>
        /// 参考班级（导航属性）
        /// </summary>
        public ICollection<ClassExamDto> ClassInfos { get; set; }

        /// <summary>
        /// 试题集合（导航属性）
        /// </summary>
        public ICollection<QuestionDto> QuestionInfos { get; set; }

        /// <summary>
        /// 答卷集合（导航属性）
        /// </summary>
        public ICollection<AnswerDto> AnswerInfos { get; set; }
    }
}
