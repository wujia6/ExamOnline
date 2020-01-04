namespace Application.DTO.Models
{
    public class AnswerDto
    {
        public int ID { get; set; }

        public string Remarks { get; set; }

        public string Result { get; set; }

        public int Score { get; set; }

        public ExaminationDto FromExamination { get; set; }

        public StudentDto FromStudent { get; set; }
    }
}
