namespace Domain.Entities.ClassAgg
{
    public class ClassExam : ClassRoot
    {
        public virtual ClassInfo ClassInfo { get; set; } = EntityFactory.CreateInstance<ClassInfo>();

        public virtual ExamAgg.ExamInfo ExamInfo { get; set; } = EntityFactory.CreateInstance<ExamAgg.ExamInfo>();
    }
}
