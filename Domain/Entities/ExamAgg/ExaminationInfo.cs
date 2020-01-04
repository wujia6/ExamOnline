using System;
using System.Collections.Generic;
using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.Entities.ExamAgg
{
    /// <summary>
    /// 考试信息实体类（聚合根）
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
        public virtual IEnumerable<TeacherInfo> TeacherInfomations { get; set; }

        //参考班级（导航属性）
        public virtual IEnumerable<ClassExamination> ClassExams { get; set; }

        //试题集合（导航属性）
        public virtual IEnumerable<QuestionInfo> QuestionInfomations { get; set; }

        //答卷集合（导航属性）
        public virtual IEnumerable<AnswerInfo> AnswerInfomations { get; set; }
    }
}
