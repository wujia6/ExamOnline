using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Models
{
    public class ApplicationUser
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(24, ErrorMessage = "账号6-24个字符，字母开头并包含字母、数字或下划线", MinimumLength = 6)]
        public string UserAccount { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z0-9_\.\@\!\#\$\%\^\&\*\(\)]{5,31}$", ErrorMessage = "登陆密码包含6-32个字母、数字或特殊符号(_!@#$%^&*())")]
        public string UserPassword { get; set; }

        [Required]
        [RegularExpression(@"^\w{5,5}$", ErrorMessage = "请输入正确的验证码")]
        public string VerificyCode { get; set; }

        public string RememberMe { get; set; }

        public int ExpireMin { get; set; } = 15;    //cookie过期时间

        public string ReturnUrl { get; set; }   //返回rul

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Tel { get; set; }

        public string CreateDate { get; set; }

        public string InRoles { get; set; }

        
    }
}
