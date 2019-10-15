using System.Runtime.Serialization;
using Domain.Entities.UserAgg;

namespace Domain.Entities.ClassAgg
{
    public class ClassTeacher : ClassRoot
    {
        [DataMember]
        public virtual ClassInfo ClassInfo { get; set; } = EntityFactory.CreateInstance<ClassInfo>();

        [DataMember]
        public virtual TeacherInfo TeacherInfo { get; set; } = EntityFactory.CreateInstance<TeacherInfo>();
    }
}
