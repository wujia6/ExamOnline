using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.IComm;

namespace Domain.Entities.ExamAgg
{
    /// <summary>
    /// 考试实体类（聚合根）
    /// </summary>
    public class ExamInfo : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        //public override Guid ID { get; set; }

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
        //public override string Remarks { get; set; }

        /// <summary>
        /// 监考老师（导航属性）
        /// </summary>
        public virtual IQueryable<UserAgg.Teacher> Teachers { get; set; } = new List<UserAgg.Teacher>().AsQueryable();

        /// <summary>
        /// 参考班级（导航属性）
        /// </summary>
        public virtual IQueryable<ClassAgg.ClassExam> ClassInfos { get; set; } = new List<ClassAgg.ClassExam>().AsQueryable();

        /// <summary>
        /// 试题集合（导航属性）
        /// </summary>
        public virtual IQueryable<QuestionAgg.QuestionInfo> QuestionInfos { get; set; } = new List<QuestionAgg.QuestionInfo>().AsQueryable();

        /// <summary>
        /// 答卷集合（导航属性）
        /// </summary>
        public virtual IQueryable<AnwserAgg.AnswerInfo> AnswerInfos { get; set; } = new List<AnwserAgg.AnswerInfo>().AsQueryable();
    }
}
