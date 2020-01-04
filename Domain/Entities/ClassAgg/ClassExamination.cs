using Domain.Entities.ExamAgg;

namespace Domain.Entities.ClassAgg
{
    public class ClassExamination : BaseEntity
    {
        public virtual ClassInfo ClassInfomation { get; set; }

        public virtual ExaminationInfo ExamInfomation { get; set; }
    }
}
