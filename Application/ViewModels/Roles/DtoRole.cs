using System.Collections.Generic;

namespace Application.ViewModels
{
    public class DtoRole
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Remarks { get; set; }

        public List<DtoMenu> DtoMenus { get; set; }

        public List<DtoUser> DtoUsers { get; set; }
    }
}
