using System.Collections.Generic;

namespace Application.DTO.Models
{
    public class StudentDto : UserDto
    {
        public string StudentNo { get; set; }

        public string IdentityNo { get; set; }

        public string ParentTel { get; set; }

        public string District { get; set; }

        public string Address { get; set; }

        public string Dormitory { get; set; }

        public ClassDto FromClass { get; set; }

        public List<AnswerDto> AnswerDtos { get; set; }
    }
}
