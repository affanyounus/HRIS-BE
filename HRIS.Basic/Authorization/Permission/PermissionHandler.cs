using System.Security.Claims;
using HRIS.Basic.Models.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HRIS.Basic.Authorization.Permission
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public PermissionHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            // Check if the user has the required claim
            // this line will check if there's any claim passed from JWT. 
            //var hasClaim = context.User.HasClaim(c => c.Type == requirement.ClaimName);

            //if (hasClaim)
            //{

            //}


            // Get the current user
            var userEmailClaim = context.User.FindFirst(ClaimTypes.Email);
            var userEmail = userEmailClaim.Value;

            if (userEmail == null)
            {
                return;
            }

            var user = await _userManager.FindByEmailAsync(userEmail);

            // Get claims directly associated with the user
            var userClaims = (from userClaim in await _userManager.GetClaimsAsync(user) select userClaim.Type).ToList();

            // Get claims from roles associated with the user
            var roleClaims = new List<string>();
            foreach (var roleName in await _userManager.GetRolesAsync(user))
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    var claims = await _roleManager.GetClaimsAsync(role);

                    roleClaims.AddRange(claims.Select(claim => claim.Type));
                }
            }
            
            // Check if requirement.ClaimName is in either userClaims or roleClaims
            if (userClaims.Any(claim => claim == requirement.ClaimName) ||
                roleClaims.Any(claim => claim == requirement.ClaimName))
            {
                // Claim found, return true
                context.Succeed(requirement);
                return;
            }

            return;
        }
    }
}
