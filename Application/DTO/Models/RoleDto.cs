using System.Collections.Generic;

namespace Application.DTO.Models
{
    public class RoleDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Remarks { get; set; }

        public List<PermissionDto> PermssionDtos { get; set; }

        //public List<MenuDto> MenuDtos { get; set; }

        public List<ApplicationUser> UserDtos { get; set; }
    }
}
