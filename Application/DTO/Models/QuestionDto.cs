namespace Application.DTO.Models
{
    public class QuestionDto
    {
        public int ID { get; set; }

        public string Remarks { get; set; }
        
        public string Category { get; set; }
        
        public string Level { get; set; }
        
        public string Title { get; set; }
        
        public string Contents { get; set; }
        
        public string Answer { get; set; }

        public ExaminationDto FromExamination { get; set; }
    }
}
