using System;
using System.Collections.Generic;
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
        public List<TeacherDTO> TeacherDtos { get; set; }

        [DataMember]
        public List<ClassExamDTO> ClassExamDtos { get; set; }

        [DataMember]
        public List<QuestionDTO> QuestionDtos { get; set; }

        [DataMember]
        public List<AnswerDTO> AnswerDtos { get; set; }
    }
}
