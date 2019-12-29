namespace Application.DTO
{
    public class UserRoleDTO : BaseModel
    {
        public UserDTO UserDto { get; set; }

        public RoleDTO RoleDto { get; set; }
    }
}
