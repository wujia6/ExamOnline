using System.Collections.Generic;

namespace Application.DTO
{
    public class RoleDTO : BaseModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public List<MenuDTO> MenuDtos { get; set; }

        public List<UserDTO> UserDtos { get; set; }
    }
}
