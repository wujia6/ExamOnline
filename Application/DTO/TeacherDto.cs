using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTO
{
    public class TeacherDTO : UserBaseDTO
    {
        public string Profssion { get; set; }
        
        public CommType Course { get; set; }

        public List<ClassTeacherDTO> ClassTeacherDtos { get; set; }
    }
}
