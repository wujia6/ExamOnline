using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Models
{
    public class TeacherDto : ApplicationUser
    {
        [Required(ErrorMessage = "请填写专业，长度 2-10个字符之间。")]
        [StringLength(10,MinimumLength = 2)]
        public string Profssion { get; set; }

        [Required(ErrorMessage = "请填写授课课程名，长度 2-10个字符之间。")]
        [StringLength(10, MinimumLength = 2)]
        public string Course { get; set; }

        public List<ClassDto> FromClass { get; set; }
    }
}
