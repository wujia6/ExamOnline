namespace Application.DTO
{
    public class ClassExaminationDTO : BaseModel
    {
        public ClassDTO ClassDto { get; set; }

        public ExaminationDTO ExaminationDto { get; set; }
    }
}
