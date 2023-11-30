using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRIS.Basic.Models.Domain;

public partial class EmployeeProjectAllocation: AuditableFields
{
    [Key]
    public Guid EmployeeProjectAllocationId{ get; set; }

    public Guid ProjectId { get; set; }

    public Guid EmployeeId { get; set; }

    public bool IsBillable { get; set; }

    public double BillableHoursAssigned { get; set; }

    public double BillableHoursWorked { get; set; }

    public double NonBillableHoursAssigned { get; set; }

    public double NonBillableHoursWorked { get; set; }

    public virtual Project Project { get; set; } = null!;

    public class EmployeeProjectAllocationConfiguration : IEntityTypeConfiguration<EmployeeProjectAllocation>
    {
        public void Configure(EntityTypeBuilder<EmployeeProjectAllocation> builder)
        {
            builder.ToTable("EmployeeProjectAllocation");
            builder.HasKey(e => e.EmployeeProjectAllocationId).HasName("PK_EmployeeProjectAllocation");

            builder.Property(e => e.EmployeeProjectAllocationId).ValueGeneratedNever();
            builder.Property(e => e.CreatedAt).HasColumnType("datetime");
            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");

            builder.HasOne(d => d.Project).WithMany(p => p.EmployeeProjectsAllocations)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeProjectAllocation_EmployeeId");
        }
    }
}
