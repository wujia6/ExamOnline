using Domain.Entities;

namespace Application.DTO
{
    public class QuestionDTO : BaseModel
    {
        public CommType Category { get; set; }
        
        public CommType Level { get; set; }
        
        public string Title { get; set; }
        
        public string Contents { get; set; }
        
        public string Answer { get; set; }
        
        public ExaminationDTO ExaminationDto { get; set; }
    }
}
