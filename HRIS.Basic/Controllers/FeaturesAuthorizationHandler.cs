using Microsoft.AspNetCore.Authorization;

namespace HRIS.Basic.Controllers
{
    public class FeaturesHandlerAttribute : AuthorizeAttribute, IAuthorizationRequirement
    {
        public FeaturesHandlerAttribute(string userId) => UserId = userId;
        public string UserId { get; }

        public IEnumerable<IAuthorizationRequirement> GetRequirements()
        {
            yield return this;
        }
    }

    public class FeaturesAuthorizationHandler : AuthorizationHandler<FeaturesHandlerAttribute>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FeaturesHandlerAttribute requirement)
        {
            throw new NotImplementedException();
        }
    }
}
