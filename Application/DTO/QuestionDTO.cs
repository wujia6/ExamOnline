using System.Runtime.Serialization;
using Domain.Entities;

namespace Application.DTO
{
    public class QuestionDTO
    {
        public int ID { get; set; }
        
        public CommType Category { get; set; }
        
        public CommType Level { get; set; }
        
        public string Title { get; set; }
        
        public string Contents { get; set; }
        
        public string Answer { get; set; }
        
        public string Remarks { get; set; }
        
        public ExaminationDTO ExaminationDto { get; set; }
    }
}
