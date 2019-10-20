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
        public List<ClassExamDTO> ClassExamDtos { get; set; }

        [DataMember]
        public List<StudentDTO> StudentDtos { get; set; }

        [DataMember]
        public List<ClassTeacherDTO> ClassTeacherDtos { get; set; }
    }
}
