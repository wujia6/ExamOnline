using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ExamUI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(20, ErrorMessage = "账号6-20个字符，字母开头并包含字母、数字或下划线", MinimumLength = 6)]
        public string Account { get; set; }

        [Required]
        [DataType(DataType.Password)]
        //[RegularExpression(@"/^([a-z0-9\_\.\@\!\#\$\%\^\&\*\(\)]){7,23}$/", ErrorMessage = "登陆密码包含8-24个字母、数字或特殊符号(_!@#$%^&*())")]
        public string Password { get; set; }

        //[Required]
        //[RegularExpression(@"^\w{4,}$", ErrorMessage = "请输入正确的验证码")]
        //public string VerificyCode { get; set; }

        //记住我
        public bool RememberMe { get; set; }

        //cookie过期时间
        public int ExpireMin { get; set; } = 15;

        //返回rul
        public string ReturnUrl { get; set; } = string.Empty;
    }
}
