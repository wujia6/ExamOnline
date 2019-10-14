using System.Runtime.Serialization;
using Domain.Entities.ExamAgg;

namespace Domain.Entities.ClassAgg
{
    public class ClassExam : ClassRoot
    {
        [DataMember]
        public virtual ClassInfo ClassInfo { get; set; } = EntityFactory.CreateInstance<ClassInfo>();

        [DataMember]
        public virtual ExamInfo ExamInfo { get; set; } = EntityFactory.CreateInstance<ExamAgg.ExamInfo>();
    }
}
