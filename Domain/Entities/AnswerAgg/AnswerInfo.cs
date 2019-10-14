using System.Runtime.Serialization;
using Domain.Entities.ExamAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.Entities.AnwserAgg
{
    public class AnswerInfo : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 结果
        /// </summary>
        [DataMember]
        public string Result { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        [DataMember]
        public int Score { get; set; }

        /// <summary>
        /// 考试信息（导航属性）
        /// </summary>
        [DataMember]
        public virtual ExamInfo ExamInfo { get; set; } = EntityFactory.CreateInstance<ExamInfo>();

        /// <summary>
        /// 学生信息（导航属性）
        /// </summary>
        [DataMember]
        public virtual StudentInfo StudentInfo { get; set; } = EntityFactory.CreateInstance<StudentInfo>();
    }
}
