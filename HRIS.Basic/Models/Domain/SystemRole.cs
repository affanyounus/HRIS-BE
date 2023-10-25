using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class SystemRole
{
    public Guid SystemRoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();


    public class SystemRoleConfiguration : IEntityTypeConfiguration<SystemRole>
    {

        public void Configure(EntityTypeBuilder<SystemRole> systemRoleBuilder)
        {
            systemRoleBuilder.ToTable("SystemRole");
            systemRoleBuilder.HasKey(e => e.SystemRoleId).HasName("PK_SystemRole");
            systemRoleBuilder.Property(e => e.SystemRoleId).ValueGeneratedNever();
            systemRoleBuilder.Property(e => e.CreatedAt).HasColumnType("datetime");
            systemRoleBuilder.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
            systemRoleBuilder.Property(e => e.UpdatedAt).HasColumnType("datetime");
            systemRoleBuilder.Property(e => e.CreatedBy).IsRequired();
            systemRoleBuilder.Property(e => e.UpdatedBy).IsRequired();

        }
    }
}
