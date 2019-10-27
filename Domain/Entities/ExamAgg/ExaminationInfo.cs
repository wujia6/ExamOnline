using System;
using System.Linq;
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
    public class ExaminationInfo : BaseEntity, IAggregateRoot
    {
        //标题
        public string Title { get; set; }
        //开始时间
        public DateTime BeginTime { get; set; }
        //结束时间
        public DateTime EndTime { get; set; }
        //监考老师（导航属性）
        public virtual IQueryable<TeacherInfo> TeacherInfomations { get; set; }
        //参考班级（导航属性）
        public virtual IQueryable<ClassExamination> ClassExams { get; set; }
        //试题集合（导航属性）
        public virtual IQueryable<QuestionInfo> QuestionInfomations { get; set; }
        //答卷集合（导航属性）
        public virtual IQueryable<AnswerInfo> AnswerInfomations { get; set; }
    }
}
