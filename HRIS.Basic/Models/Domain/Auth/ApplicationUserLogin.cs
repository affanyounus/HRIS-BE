using Microsoft.AspNetCore.Identity;

namespace HRIS.Basic.Models.Domain.Auth
{
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
