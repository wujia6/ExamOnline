namespace Application.DTO
{
    public class ClassTeacherDTO : BaseModel
    {
        public ClassDTO ClassDto { get; set; }
        
        public TeacherDTO TeacherDto { get; set; }
    }
}
