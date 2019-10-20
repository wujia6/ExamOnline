using Domain.Entities.UserAgg;

namespace Domain.Entities.ClassAgg
{
    public class ClassTeacher : ClassRoot
    {
        public virtual ClassInfo ClassInfomation { get; set; } = EntityFactory.Create<ClassInfo>();

        public virtual TeacherInfo TeacherInfomation { get; set; } = EntityFactory.Create<TeacherInfo>();
    }
}
