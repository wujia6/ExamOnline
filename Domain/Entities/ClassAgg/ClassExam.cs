using System;

namespace Domain.Entities.ClassAgg
{
    public class ClassExam : ClassRoot
    {
        public override Guid ID { get; set; }

        public virtual ClassInfo ClassInfo { get; set; } = EntityFactory.CreateInstance<ClassInfo>();

        public virtual ExamAgg.ExamInfo ExamInfo { get; set; } = EntityFactory.CreateInstance<ExamAgg.ExamInfo>();
    }
}
