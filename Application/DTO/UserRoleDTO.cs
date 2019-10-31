﻿namespace Application.DTO
{
    public class UserRoleDTO
    {
        public int ID { get; set; }

        public string Remark { get; set; }

        public UserDTO UserDto { get; set; }

        public RoleDTO RoleDto { get; set; }
    }
}