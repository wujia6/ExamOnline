using Domain.Entities.ExamAgg;

namespace Domain.Entities.ClassAgg
{
    public class ClassExamination : ClassBase
    {
        public virtual ClassInfo ClassInfomation { get; set; }

        public virtual ExaminationInfo ExamInfomation { get; set; }
    }
}
