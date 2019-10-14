using System.Runtime.Serialization;
using Domain.Entities;

namespace Application.DTO
{
    public class QuestionDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public CommType Category { get; set; }

        [DataMember]
        public CommType Level { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Contents { get; set; }

        [DataMember]
        public string Answer { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public ExamDTO ExamDto { get; set; }
    }
}
