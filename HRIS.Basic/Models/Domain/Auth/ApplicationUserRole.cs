using Microsoft.AspNetCore.Identity;

namespace HRIS.Basic.Models.Domain.Auth
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
