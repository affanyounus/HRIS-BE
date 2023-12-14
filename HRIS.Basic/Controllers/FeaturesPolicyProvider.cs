using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Options;

namespace HRIS.Basic.Controllers
{
    public class FeaturesPolicyProvider: IAuthorizationPolicyProvider
    {
        const string POLICY_PREFIX = "RolesAllowed";
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }


        public FeaturesPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);

        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return FallbackPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        {
            return FallbackPolicyProvider.GetFallbackPolicyAsync();
        }


        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
                int.TryParse(policyName.Substring(POLICY_PREFIX.Length), out var userId))
            {
                var policy = new AuthorizationPolicyBuilder(
                    JwtBearerDefaults.AuthenticationScheme);
                //policy.AddRequirements(new FeaturesAllowedRequirement(userId));
                return Task.FromResult<AuthorizationPolicy?>(policy.Build());
            }

            return Task.FromResult<AuthorizationPolicy?>(null);
        }

       

      
    }
}
