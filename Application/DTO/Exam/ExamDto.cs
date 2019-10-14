using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Application.DTO
{
    public class ExamDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime BeginTime { get; set; }

        [DataMember]
        public DateTime EndTime { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public IQueryable<TeacherDTO> TeacherDtos { get; set; }

        [DataMember]
        public IQueryable<ClassExamDTO> ClassExamDtos { get; set; }

        [DataMember]
        public IQueryable<QuestionDTO> QuestionDtos { get; set; }

        [DataMember]
        public IQueryable<AnswerDTO> AnswerDtos { get; set; }
    }
}
