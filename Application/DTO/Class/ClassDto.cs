using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Entities;

namespace Application.DTO
{
    public class ClassDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ClassGrade Grade { get; set; }

        [DataMember]
        public CommType Category { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public ClassStatus Status { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public ICollection<ClassExamDTO> ClassExamDtos { get; set; }

        [DataMember]
        public ICollection<StudentDTO> StudentDtos { get; set; }

        [DataMember]
        public ICollection<ClassTeacherDTO> ClassTeacherDtos { get; set; }
    }
}
