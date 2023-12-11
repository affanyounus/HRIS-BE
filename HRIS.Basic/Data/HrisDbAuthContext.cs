using HRIS.Basic.Models.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HRIS.Basic.Data;

public partial class HrisDbAuthContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
{
    public HrisDbAuthContext()
    {
    }

    public HrisDbAuthContext(DbContextOptions<HrisDbAuthContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
    //Follow this Documentation to get along with IdentityCore
    //https://learn.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-7.0


        base.OnModelCreating(builder);

        // Create default roles for authorization
        var adminId = Guid.NewGuid();
        var editorId = Guid.NewGuid();
        var viewerId = Guid.NewGuid();

        var roles = new List<ApplicationRole>
        {
            new ApplicationRole
            {
                Id = adminId,
                Name = "Admin",
                NormalizedName = "Administrator".ToUpper()
            },
            new ApplicationRole
            {
                Id = editorId,
                Name = "Editor",
                NormalizedName = "Editor".ToUpper()
            },
            new ApplicationRole
            {
            Id = viewerId,
            Name = "Viewer",
            NormalizedName = "Viewer".ToUpper()
            }
        };



        builder.Entity<ApplicationUser>(b =>
        {
            // Each User can have many UserClaims
            b.HasMany(e => e.Claims)
                .WithOne(e => e.User)
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins
            b.HasMany(e => e.Logins)
                .WithOne(e => e.User)
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            b.HasMany(e => e.Tokens)
                .WithOne(e => e.User)
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
            .IsRequired();
        });

        builder.Entity<ApplicationRole>(b =>
        {
            // Each Role can have many entries in the UserRole join table
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            // Each Role can have many associated RoleClaims
            b.HasMany(e => e.RoleClaims)
                .WithOne(e => e.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();
        });


        //Data Insertion in time of migration
        builder.Entity<ApplicationRole>().HasData(roles);

    }



}
