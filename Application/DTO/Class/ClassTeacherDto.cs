using System.Runtime.Serialization;

namespace Application.DTO
{
    public class ClassTeacherDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public ClassDTO ClassDto { get; set; }

        [DataMember]
        public TeacherDTO TeacherDto { get; set; }
    }
}
