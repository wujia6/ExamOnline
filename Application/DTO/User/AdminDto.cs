using System;
using System.Runtime.Serialization;
using Domain.Entities;

namespace Application.DTO
{
    public class AdminDTO
    {
        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        public string Account { get; set; }

        [DataMember]
        public string Pwd { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Gender Gender { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string Tel { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public string Remarks { get; set; }
    }
}
