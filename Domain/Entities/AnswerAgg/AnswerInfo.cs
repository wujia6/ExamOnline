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
        public string Result { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 考试信息（导航属性）
        /// </summary>
        public virtual ExaminationInfo ExamInfomation { get; set; } = EntityFactory.Create<ExaminationInfo>();

        /// <summary>
        /// 学生信息（导航属性）
        /// </summary>
        public virtual StudentInfo StudentInfomation { get; set; } = EntityFactory.Create<StudentInfo>();
    }
}
