using System;
using System.Collections.Generic;

namespace Application.DTO
{
    public class ExaminationDTO : BaseModel
    {
        public string Title { get; set; }
        
        public DateTime BeginTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public List<TeacherDTO> TeacherDtos { get; set; }
        
        public List<ClassExaminationDTO> ClassExamDtos { get; set; }
        
        public List<QuestionDTO> QuestionDtos { get; set; }
        
        public List<AnswerDTO> AnswerDtos { get; set; }
    }
}
