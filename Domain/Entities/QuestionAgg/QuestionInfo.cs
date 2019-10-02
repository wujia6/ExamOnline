using System;
using Domain.Entities.ExamAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.Entities.QuestionAgg
{
    /// <summary>
    /// 试题聚合根
    /// </summary>
    public class QuestionInfo : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        public override Guid ID { get; set; }

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
        public override string Remarks { get; set; }

        /// <summary>
        /// 考试信息（导航属性）
        /// </summary>
        public virtual ExamInfo ExamInfo { get; set; }
    }
}
