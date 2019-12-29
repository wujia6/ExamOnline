namespace Application.DTO
{
    public class RoleMenuDTO : BaseModel
    {
        public RoleDTO RoleDto { get; set; }

        public MenuDTO MenuDto { get; set; }
    }
}
