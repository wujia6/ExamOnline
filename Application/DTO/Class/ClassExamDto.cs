using System;

namespace Application.DTO
{
    public class ClassExamDTO
    {
        public Guid ID { get; set; }

        public ClassDTO ClassInfo { get; set; }

        public ExamDTO ExamInfo { get; set; }
    }
}
