using System.Collections.Generic;

namespace Application.DTO
{
    public class UserDTO : BaseModel
    {
        public string Account { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Tel { get; set; }

        public string CreateDate { get; set; }

        //public string TobeRoles { get; set; }

        public List<UserRoleDTO> UserRoleDtos { get; set; }
    }
}
