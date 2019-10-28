using System.Collections.Generic;

namespace Application.DTO
{
    public class StudentDTO : UserDTO
    {
        public string StudentNo { get; set; }
        
        public string IdentityNo { get; set; }
        
        public string ParentTel { get; set; }
        
        public string District { get; set; }
        
        public string Address { get; set; }
        
        public string Dormitory { get; set; }
        
        public ClassDTO ClassDto { get; set; }
        
        public List<AnswerDTO> AnswerDtos { get; set; }
    }
}
