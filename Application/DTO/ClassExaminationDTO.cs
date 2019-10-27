using System.Runtime.Serialization;

namespace Application.DTO
{
    public class ClassExaminationDTO
    {
        public int ID { get; set; }

        public ClassDTO ClassDto { get; set; }

        public ExaminationDTO ExaminationDto { get; set; }
    }
}
