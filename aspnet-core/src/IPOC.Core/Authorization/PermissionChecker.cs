using Abp.Authorization;
using IPOC.Authorization.Roles;
using IPOC.Authorization.Users;

namespace IPOC.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
