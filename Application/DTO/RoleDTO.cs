﻿using System.Collections.Generic;

namespace Application.DTO
{
    public class RoleDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Remarks { get; set; }

        public virtual List<RoleMenuDTO> RoleMenuDtos { get; set; }

        public virtual List<UserRoleDTO> UserRoleDtos { get; set; }
    }
}
