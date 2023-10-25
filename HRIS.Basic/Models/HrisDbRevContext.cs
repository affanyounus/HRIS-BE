using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Basic.Models;

public partial class HrisDbRevContext : DbContext
{
    public HrisDbRevContext()
    {
    }

    public HrisDbRevContext(DbContextOptions<HrisDbRevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<EmployeeRoleAdditionalPermission> EmployeeRoleAdditionalPermissions { get; set; }

    public virtual DbSet<EmployeeRolePermission> EmployeeRolePermissions { get; set; }

    public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }

    public virtual DbSet<EmploymentStatus> EmploymentStatuses { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SystemRole> SystemRoles { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\;Database=HRIS_DB_REV;Trusted_Connection=True; Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_Employee_1");

            entity.ToTable("Employee");

            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Cnic).HasMaxLength(255);
            entity.Property(e => e.CompanyEmailAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.JoiningDate).HasColumnType("date");
            entity.Property(e => e.PersonalEmailAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.EmployeeRole).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_EmployeeRoleId");

            entity.HasOne(d => d.EmploymentStatus).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmploymentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_EmploymentStatusId");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_JobId");
        });

        modelBuilder.Entity<EmployeeAttendance>(entity =>
        {
            entity.ToTable("EmployeeAttendance");

            entity.Property(e => e.EmployeeAttendanceId).ValueGeneratedOnAdd();
            entity.Property(e => e.AttendanceDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.EmployeeAttendanceNavigation).WithOne(p => p.EmployeeAttendance)
                .HasForeignKey<EmployeeAttendance>(d => d.EmployeeAttendanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeAttendance_EmployeeId");
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.ToTable("EmployeeRole");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeRoleAdditionalPermission>(entity =>
        {
            entity.ToTable("EmployeeRoleAdditionalPermission");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Permission)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeRoleAdditionalPermissions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeRoleAdditionalPermission_EmployeeId");
        });

        modelBuilder.Entity<EmployeeRolePermission>(entity =>
        {
            entity.ToTable("EmployeeRolePermission");

            entity.Property(e => e.EmployeeRolePermissionId).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Permission)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.EmployeeRolePermissionNavigation).WithOne(p => p.EmployeeRolePermission)
                .HasForeignKey<EmployeeRolePermission>(d => d.EmployeeRolePermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeRolePermission_EmployeeRoleId");
        });

        modelBuilder.Entity<EmployeeSkill>(entity =>
        {
            entity.ToTable("EmployeeSkill");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSkills)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSkill_EmployeeId");

            entity.HasOne(d => d.Skill).WithMany(p => p.EmployeeSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSkill_SkillId");
        });

        modelBuilder.Entity<EmploymentStatus>(entity =>
        {
            entity.ToTable("EmploymentStatus");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.ToTable("Job");

            entity.Property(e => e.JobId).ValueGeneratedOnAdd();
            entity.Property(e => e.Classification)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.JobNavigation).WithOne(p => p.Job)
                .HasForeignKey<Job>(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Job_EmploymentStatusId");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.ToTable("Skill");

            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SystemRole>(entity =>
        {
            entity.ToTable("SystemRole");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Employee");

            entity.ToTable("User");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasColumnType("datetime");

            entity.HasOne(d => d.SystemRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.SystemRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_SystemRoleId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
