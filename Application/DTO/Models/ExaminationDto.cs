using System.Collections.Generic;

namespace Application.DTO.Models
{
    public class ExaminationDto
    {
        public int ID { get; set; }

        public string Remarks { get; set; }

        public string Title { get; set; }

        public string BeginTime { get; set; }

        public string EndTime { get; set; }

        public List<TeacherDto> TeacherDtos { get; set; }

        public List<ClassDto> ClassDtos { get; set; }

        public List<AnswerDto> AnswerDtos { get; set; }

        public List<QuestionDto> QuestionDtos { get; set; }
    }
}
