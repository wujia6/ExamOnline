using System;
using Domain.Entities;

namespace Application.DTO
{
    public class QuestionDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// 试题类别
        /// </summary>
        public CommType Category { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public CommType Level { get; set; }

        /// <summary>
        /// 试题标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 试题类容
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 试题答案
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 考试信息（导航属性）
        /// </summary>
        public ExamDTO ExamInfo { get; set; }
    }
}
