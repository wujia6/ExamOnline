﻿using System.Runtime.Serialization;

namespace Application.DTO
{
    public class AnswerDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Result { get; set; }

        [DataMember]
        public int Score { get; set; }

        [DataMember]
        public ExamDTO ExamDTO { get; set; }

        [DataMember]
        public StudentDTO StudentDTO { get; set; }
    }
}
