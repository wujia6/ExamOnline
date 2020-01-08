using System.Collections.Generic;

namespace Application.DTO.Models
{
    public class MenuDto
    {
        public int ID { get; set; }

        public int ParentID { get; set; }

        public string MenuType { get; set; }

        public string Title { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Remarks { get; set; }

        public List<MenuDto> ChildNodes { get; set; }
    }
}
