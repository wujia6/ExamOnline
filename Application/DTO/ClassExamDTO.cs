using System.Runtime.Serialization;

namespace Application.DTO
{
    public class ClassExamDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public ClassDTO ClassDto { get; set; }

        [DataMember]
        public ExamDTO ExamDto { get; set; }
    }
}
