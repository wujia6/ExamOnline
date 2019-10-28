using System.ComponentModel.DataAnnotations;

namespace ExamUI.Models
{
    public class SignInViewModel
    {
        [Required]
        [StringLength(20,ErrorMessage = "账号6-20个字符，字母开头并包含字母、数字或下划线",MinimumLength =6)]
        public string Account { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^\w+${6，30}", ErrorMessage = "密码格式有误,只能是字母、数字或者下划线")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^\w{4,}$", ErrorMessage = "请输入正确的验证码")]
        public string VerificyCode { get; set; }

        public bool RememberMe { get; set; } = false;

        public int ExpireMin { get; set; } = 15;
    }
}
