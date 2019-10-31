using System.Security.Claims;
using System.Security.Principal;
using Application.DTO;
using Newtonsoft.Json;

namespace Application.Authentication
{
    /// <summary>
    /// 自定义身份证件类
    /// </summary>
    public class CustomIdentity : IIdentity
    {
        private Claim claimInfo;

        private string roleName = string.Empty;

        public CustomIdentity(Claim claim)
        {
            claimInfo = claim;
        }

        public UserDTO UserData => JsonConvert.DeserializeObject<UserDTO>(claimInfo.Value);

        public int UserId => UserData.ID;

        public string Name => UserData.Account;

        public string RoleName
        {
            get
            {
                UserData.UserRoleDtos.ForEach(x => roleName += x.RoleDto.Name + ",");
                roleName = roleName.Remove(-1, 1);
                return roleName;
            }
        } 

        public string AuthenticationType => "Forms";

        public bool IsAuthenticated => true;
    }
}
