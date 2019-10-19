using System.Runtime.Serialization;
using Domain.Entities.ExamAgg;

namespace Domain.Entities.ClassAgg
{
    public class ClassExam : ClassRoot
    {
        [DataMember]
        public virtual ClassInfo ClassInfomation { get; set; } = EntityFactory.Create<ClassInfo>();

        [DataMember]
        public virtual ExamInfo ExamInfomation { get; set; } = EntityFactory.Create<ExamAgg.ExamInfo>();
    }
}
