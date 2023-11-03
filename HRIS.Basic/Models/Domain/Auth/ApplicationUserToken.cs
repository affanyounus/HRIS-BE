using Microsoft.AspNetCore.Identity;

namespace HRIS.Basic.Models.Domain.Auth
{
    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
