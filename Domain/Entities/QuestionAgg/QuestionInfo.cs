using System.Runtime.Serialization;
using Domain.Entities.ExamAgg;
using Domain.IComm;

namespace Domain.Entities.QuestionAgg
{
    /// <summary>
    /// 试题聚合根
    /// </summary>
    public class QuestionInfo : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 试题类别
        /// </summary>
        [DataMember]
        public CommType Category { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [DataMember]
        public CommType Level { get; set; }

        /// <summary>
        /// 试题标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 试题类容
        /// </summary>
        [DataMember]
        public string Contents { get; set; }

        /// <summary>
        /// 试题答案
        /// </summary>
        [DataMember]
        public string Answer { get; set; }

        /// <summary>
        /// 考试信息（导航属性）
        /// </summary>
        [DataMember]
        public virtual ExamInfo ExamInfo { get; set; }
    }
}
