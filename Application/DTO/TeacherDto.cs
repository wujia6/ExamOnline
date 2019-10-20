using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Entities;

namespace Application.DTO
{
    public class TeacherDTO
    {
        [DataMember]
        public int ID { get; set; }

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
        public string Profssion { get; set; }

        [DataMember]
        public CommType Course { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        public List<ClassTeacherDTO> ClassTeacherDtos { get; set; }
    }
}
