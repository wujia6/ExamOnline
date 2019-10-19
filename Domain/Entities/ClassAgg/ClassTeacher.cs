using System.Runtime.Serialization;
using Domain.Entities.UserAgg;

namespace Domain.Entities.ClassAgg
{
    public class ClassTeacher : ClassRoot
    {
        [DataMember]
        public virtual ClassInfo ClassInfomation { get; set; } = EntityFactory.Create<ClassInfo>();

        [DataMember]
        public virtual TeacherInfo TeacherInfomation { get; set; } = EntityFactory.Create<TeacherInfo>();
    }
}
