using System.Collections.Generic;

namespace Application.DTO.Models
{
    public class ClassDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Grade { get; set; }

        public string Category { get; set; }

        public string CreateDate { get; set; }

        public string Status { get; set; }

        public string Remarks { get; set; }

        public List<TeacherDto> TeacherDtos { get; set; }

        public List<StudentDto> StudentDtos { get; set; }

        public List<ExaminationDto> Examinations { get; set; }

    }
}
