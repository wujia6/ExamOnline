using System;

namespace Application.DTO
{
    public class ClassTeacherDto
    {
        public Guid ID { get; set; }

        public ClassDto ClassInfo { get; set; }

        public TeacherDto Teacher { get; set; }

        public string Remarks { get; set; }
    }
}
