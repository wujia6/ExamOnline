using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Models
{
    public class MenuDto
    {
        public int ID { get; set; }

        [Required]
        public int ParentID { get; set; }

        [Required]
        public string MenuType { get; set; }

        [Required]
        //[RegularExpression(@"^[\u4E00 - \u9FA5]{3, 15}$", ErrorMessage = "标题文本2-8个中文字符")]
        public string Title { get; set; }

        [Required]
        //[RegularExpression(@"^[a-zA-Z]{3, 19}$", ErrorMessage = "模块文本4-20个英文字符")]
        public string Controller { get; set; }

        [Required]
        //[RegularExpression(@"^[a-zA-Z]{3, 19}$", ErrorMessage = "功能文本4-20个英文字符")]
        public string Action { get; set; }

        //[StringLength(49, ErrorMessage = "备注文本0-50个字符")]
        public string Remarks { get; set; }

        public List<MenuDto> ChildNodes { get; set; }
    }
}
