﻿using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTO
{
    public class UserDTO
    {
        public int ID { get; set; }

        public string Account { get; set; }

        public string Pwd { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public string Tel { get; set; }

        public DateTime CreateDate { get; set; }

        public string Remarks { get; set; }

        public List<UserRoleDTO> UserRoleDtos { get; set; }
    }
}