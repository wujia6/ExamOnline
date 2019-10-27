using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTO
{
    public class MenuDTO
    {
        public int ID { get; set; }

        public int ParentId { get; set; }

        public CommType MenuType { get; set; } = CommType.menu;

        public string Title { get; set; }

        public string Code { get; set; }

        public string Url { get; set; }

        public string Remarks { get; set; }

        public List<RoleMenuDTO> RoleMenuDtos { get; set; }
    }
}
