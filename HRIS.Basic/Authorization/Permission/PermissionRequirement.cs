using Microsoft.AspNetCore.Authorization;

namespace HRIS.Basic.Authorization.Permission
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string ClaimName { get; }

        public PermissionRequirement(string claimName)
        {
            ClaimName = claimName;
        }
    }
}
