using System;

namespace Application.DTO
{
    public class ClassTeacherDTO
    {
        public Guid ID { get; set; }

        public ClassDTO ClassInfo { get; set; }

        public TeacherDTO Teacher { get; set; }

        public string Remarks { get; set; }
    }
}
