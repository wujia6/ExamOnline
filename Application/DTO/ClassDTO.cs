﻿using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTO
{
    public class ClassDTO
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public ClassGrade Grade { get; set; }
        
        public CommType Category { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public ClassStatus Status { get; set; }
        
        public string Remarks { get; set; }
        
        public List<ClassExaminationDTO> ClassExaminationDtos { get; set; }
        
        public List<StudentDTO> StudentDtos { get; set; }
        
        public List<ClassTeacherDTO> ClassTeacherDtos { get; set; }
    }
}
