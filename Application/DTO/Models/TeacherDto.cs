using System.Collections.Generic;

namespace Application.DTO.Models
{
    public class TeacherDto : UserDto
    {
        public string Profssion { get; set; }
        
        public string Course { get; set; }

        public List<ClassDto> FromClass { get; set; }
    }
}
