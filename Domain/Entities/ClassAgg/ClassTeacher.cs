namespace Domain.Entities.ClassAgg
{
    public class ClassTeacher : ClassRoot
    {
        public virtual ClassInfo ClassInfo { get; set; }

        public virtual UserAgg.TeacherInfo TeacherInfo { get; set; }
    }
}
