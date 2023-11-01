using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class Employee: AuditableFields
{
    [Key]
    public Guid EmployeeId { get; set; }

    public Guid EmploymentStatusId { get; set; }

    public Guid EmployeeRoleId { get; set; }

    public Guid UserId { get; set; }

    public Guid JobId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Cnic { get; set; } = null!;

    public DateTime JoiningDate { get; set; }

    public string PersonalEmailAddress { get; set; } = null!;

    public string CompanyEmailAddress { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string State { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<EmployeeAttendance> EmployeeAttendances { get; set; } = new List<EmployeeAttendance>();

    public virtual EmployeeRole EmployeeRole { get; set; } = null!;

    public virtual EmployeeRoleAdditionalPermission? EmployeeRoleAdditionalPermission { get; set; }

    public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();

    public virtual EmploymentStatus EmploymentStatus { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();


    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> employeeBuilder)
        {
            employeeBuilder.ToTable("Employee");

            employeeBuilder.HasKey(e => e.EmployeeId).HasName("PK_Employee_1");
            employeeBuilder.Property(e => e.EmployeeId).ValueGeneratedNever();
            employeeBuilder.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            employeeBuilder.Property(e => e.Cnic).HasMaxLength(255);
            employeeBuilder.Property(e => e.CompanyEmailAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            employeeBuilder.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);
            employeeBuilder.Property(e => e.CreatedAt).HasColumnType("datetime");
            employeeBuilder.Property(e => e.DateOfBirth).HasColumnType("date");
            employeeBuilder.Property(e => e.JoiningDate).HasColumnType("date");
            employeeBuilder.Property(e => e.PersonalEmailAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            employeeBuilder.Property(e => e.State)
                .HasMaxLength(255)
                .IsUnicode(false);
            employeeBuilder.Property(e => e.UpdatedAt).HasColumnType("datetime");
            employeeBuilder.Property(e => e.CreatedAt).IsRequired();
            employeeBuilder.Property(e => e.UpdatedAt).IsRequired();


            //Relation with Employee Role - Employee can have single role at a time
            employeeBuilder.HasOne(d => d.EmployeeRole).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_EmployeeRoleId");


            //Relation with Employement Status - Employee can have single employment status at a time
            employeeBuilder.HasOne(d => d.EmploymentStatus).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmploymentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_EmploymentStatusId");

        }
    }
}
