using System.Runtime.Serialization;

namespace Application.DTO
{
    public class ClassTeacherDTO
    {
        public int ID { get; set; }
        
        public ClassDTO ClassDto { get; set; }
        
        public TeacherDTO TeacherDto { get; set; }
    }
}
