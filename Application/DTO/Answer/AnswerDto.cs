using System;

namespace Application.DTO
{
    public class AnswerDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 考试信息（导航属性）
        /// </summary>
        public ExamDTO ExamInfo { get; set; }

        /// <summary>
        /// 学生信息（导航属性）
        /// </summary>
        public StudentDTO Student { get; set; }
    }
}
