namespace Application.DTO
{
    public class AnswerDTO : BaseModel
    {
        public string Result { get; set; }
        
        public int Score { get; set; }
        
        public ExaminationDTO ExamDto { get; set; }
        
        public StudentDTO StudentDto { get; set; }
    }
}
