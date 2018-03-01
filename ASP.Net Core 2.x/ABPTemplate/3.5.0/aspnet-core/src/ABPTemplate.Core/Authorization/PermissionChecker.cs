using Abp.Authorization;
using ABPTemplate.Authorization.Roles;
using ABPTemplate.Authorization.Users;

namespace ABPTemplate.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
