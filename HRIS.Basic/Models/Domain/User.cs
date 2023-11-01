using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRIS.Basic.Models.Domain;

public partial class User: AuditableFields
{
    [Key]
    public Guid UserId { get; set; }

    public Guid SystemRoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual SystemRole SystemRole { get; set; } = null!;


    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId).HasName("PK_User");

            builder.ToTable("User");

            builder.Property(e => e.UserId).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedAt).HasColumnType("datetime");
            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");

            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.UpdatedBy).IsRequired();

            builder.HasOne(d => d.SystemRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.SystemRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_SystemRoleId");
        }
    }
}
