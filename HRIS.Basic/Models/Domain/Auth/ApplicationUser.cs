using Microsoft.AspNetCore.Identity;

namespace HRIS.Basic.Models.Domain.Auth
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        //here custom data tags/attributes can be defined.

        public string FullName { get; set; }

        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
