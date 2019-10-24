namespace Application.DTO
{
    public class UserRoleDTO
    {
        public int ID { get; set; }

        public string Remark { get; set; }

        public virtual UserRootDTO UserDto { get; set; }

        public virtual RoleDTO RoleDto { get; set; }
    }
}
