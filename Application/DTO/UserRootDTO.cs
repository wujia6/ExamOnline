using System;
using Domain.Entities;

namespace Application.DTO
{
    public abstract class UserRootDTO
    {
        public int ID { get; set; }
        
        public string Remarks { get; set; }

        public string Account { get; set; }

        public string Pwd { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; } = Gender.男;

        public int Age { get; set; }

        public string Tel { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
