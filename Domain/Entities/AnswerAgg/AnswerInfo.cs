using System;
using Domain.IComm;

namespace Domain.Entities.AnwserAgg
{
    public class AnswerInfo : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        //public override Guid ID { get; set; }

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
        public virtual ExamAgg.ExamInfo ExamInfo { get; set; } = new ExamAgg.ExamInfo();

        /// <summary>
        /// 学生信息（导航属性）
        /// </summary>
        public virtual UserAgg.Student Student { get; set; } = new UserAgg.Student();
    }
}
