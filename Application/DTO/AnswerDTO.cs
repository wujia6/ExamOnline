namespace Application.DTO
{
    public class AnswerDTO
    {
        public int ID { get; set; }
        
        public string Result { get; set; }
        
        public int Score { get; set; }
        
        public ExaminationDTO ExamDto { get; set; }
        
        public StudentDTO StudentDto { get; set; }
    }
}
