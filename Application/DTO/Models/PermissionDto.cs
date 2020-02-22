using System.Collections.Generic;

namespace Application.DTO.Models
{
    public class PermissionDto
    {
        public int ID { get; set; }

        public string Remarks { get; set; }

        public string LevelID { get; set; }

        public string TypeAt { get; set; }

        public string Named { get; set; }

        public string Command { get; set; }

        public List<PermissionDto> Childs { get; set; }
    }
}
