using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTO
{
    public class MenuDTO : BaseModel
    {
        public int ParentId { get; set; }

        public CommType MenuType { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }

        public string Url { get; set; }

        public List<RoleMenuDTO> RoleMenuDtos { get; set; }
    }
}
