using Domain.Entities.ExamAgg;

namespace Domain.Entities.ClassAgg
{
    public class ClassExam : ClassRoot
    {
        public virtual ClassInfo ClassInfomation { get; set; } = EntityFactory.Create<ClassInfo>();

        public virtual ExamInfo ExamInfomation { get; set; } = EntityFactory.Create<ExamAgg.ExamInfo>();
    }
}
