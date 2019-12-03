using Domain.Entities.UserAgg;

namespace Domain.Entities.ClassAgg
{
    public class ClassTeacher : ClassBase
    {
        public virtual ClassInfo ClassInfomation { get; set; }

        public virtual TeacherInfo TeacherInfomation { get; set; }
    }
}
