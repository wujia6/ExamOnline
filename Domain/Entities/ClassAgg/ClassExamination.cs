using Domain.Entities.ExamAgg;

namespace Domain.Entities.ClassAgg
{
    public class ClassExamination : ClassBase
    {
        public virtual ClassInfo ClassInfomation { get; set; } = EntityFactory.Create<ClassInfo>();

        public virtual ExaminationInfo ExamInfomation { get; set; } = EntityFactory.Create<ExaminationInfo>();
    }
}
