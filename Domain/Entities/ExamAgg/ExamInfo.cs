using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.Entities.ExamAgg
{
    /// <summary>
    /// 考试实体类（聚合根）
    /// </summary>
    public class ExamInfo : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember]
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 监考老师（导航属性）
        /// </summary>
        [DataMember]
        public virtual IQueryable<TeacherInfo> TeacherInfomations { get; set; } = new List<TeacherInfo>().AsQueryable();

        /// <summary>
        /// 参考班级（导航属性）
        /// </summary>
        [DataMember]
        public virtual IQueryable<ClassExam> ClassExams { get; set; } = new List<ClassExam>().AsQueryable();

        /// <summary>
        /// 试题集合（导航属性）
        /// </summary>
        [DataMember]
        public virtual IQueryable<QuestionInfo> QuestionInfomations { get; set; } = new List<QuestionInfo>().AsQueryable();

        /// <summary>
        /// 答卷集合（导航属性）
        /// </summary>
        [DataMember]
        public virtual IQueryable<AnswerInfo> AnswerInfomations { get; set; } = new List<AnswerInfo>().AsQueryable();
    }
}
