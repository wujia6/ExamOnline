namespace Application.DTO
{
    public class RoleMenuDTO
    {
        public int ID { get; set; }

        public string Remarks { get; set; }

        public RoleDTO RoleDto { get; set; }

        public MenuDTO MenuDto { get; set; }
    }
}
