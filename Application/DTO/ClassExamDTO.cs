using System.Runtime.Serialization;

namespace Application.DTO
{
    public class ClassExamDTO
    {
        [DataMember]
        public int ID { get; set; }

        public ClassDTO ClassDto { get; set; }

        public ExamDTO ExamDto { get; set; }
    }
}
