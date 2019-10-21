using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Entities;

namespace Application.DTO
{
    public class StudentDTO : UserRootDTO
    {
        [DataMember]
        public string Account { get; set; }

        [DataMember]
        public string Pwd { get; set; }

        [DataMember]
        public string StudentNo { get; set; }
        
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Gender Gender { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string IdentityNo { get; set; }

        [DataMember]
        public string Tel { get; set; }

        [DataMember]
        public string ParentTel { get; set; }

        [DataMember]
        public string District { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Dormitory { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public ClassDTO ClassDto { get; set; }

        [DataMember]
        public List<AnswerDTO> AnswerDtos { get; set; }
    }
}
