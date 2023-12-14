using Microsoft.AspNetCore.Authorization;

namespace HRIS.Basic.Controllers
{
    public class FeaturesAllowedRequirement: IAuthorizationRequirement
    {
        public string UserId { get; private set; }

        public FeaturesAllowedRequirement(string userId)
        {
            UserId = userId;
        }
    }
}
