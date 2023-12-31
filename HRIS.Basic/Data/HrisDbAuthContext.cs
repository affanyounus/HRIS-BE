﻿using HRIS.Basic.Models.Domain.Auth;
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
                NormalizedName = "Administrator".ToUpper(),
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


        var roleClaimAdmin = new List<ApplicationRoleClaim>
        {
            new ApplicationRoleClaim
            {
                Id = 1,
                ClaimType = "role",
                ClaimValue = "Create",
                RoleId = adminId
            },
            new ApplicationRoleClaim
            {
                Id = 2,
                ClaimType = "role",
                ClaimValue = "Read",
                RoleId = adminId
            },
            new ApplicationRoleClaim
            {
                Id = 3,
                ClaimType = "role",
                ClaimValue = "Edit",
                RoleId = adminId
            },
            new ApplicationRoleClaim
            {
                Id = 4,
                ClaimType = "role",
                ClaimValue = "Delete",
                RoleId = adminId
            }
        };

        var roleClaimViewer = new List<ApplicationRoleClaim>
        {
           
            new ApplicationRoleClaim
            {
                Id = 5,
                ClaimType = "role",
                ClaimValue = "Read",
                RoleId = viewerId
            }
        };

        var roleClaimEditor = new List<ApplicationRoleClaim>
        {

            new ApplicationRoleClaim
            {
                Id = 6,
                ClaimType = "role",
                ClaimValue = "Edit",
                RoleId = editorId
            }
        };

        //var roleClaimAdminExtra = new List<ApplicationRoleClaim>
        //{
        //    new ApplicationRoleClaim
        //    {
        //        Id = 7,
        //        ClaimType = "role",
        //        ClaimValue = "burnup"

        //    }
        //};



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
        builder.Entity<ApplicationRoleClaim>().HasData(roleClaimAdmin);
        builder.Entity<ApplicationRoleClaim>().HasData(roleClaimViewer);
        builder.Entity<ApplicationRoleClaim>().HasData(roleClaimEditor);

    }



}
