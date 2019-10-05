using System;

namespace Application.DTO
{
    public class ClassExamDto
    {
        public Guid ID { get; set; }

        public ClassDto ClassInfo { get; set; }

        public ExamDto ExamInfo { get; set; }
    }
}
