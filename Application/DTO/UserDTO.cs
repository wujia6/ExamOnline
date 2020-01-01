namespace Application.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }

        public string UserAccount { get; set; }

        public string UserPassword { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Tel { get; set; }

        public string CreateDate { get; set; }

        public string InRoles { get; set; }

        //public List<UserRoleDTO> UserRoleDtos { get; set; }
    }
}
