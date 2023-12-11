using HRIS.Basic.Models.Domain;
using HRIS.Basic.Models.Domain.Auth;

namespace HRIS.Basic.Data;

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

    public virtual DbSet<EmployeeAttendanceLog> EmployeeAttendanceLogs { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<EmployeeRoleAdditionalPermission> EmployeeRoleAdditionalPermissions { get; set; }

    public virtual DbSet<EmployeeRolePermission> EmployeeRolePermissions { get; set; }

    public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }

    public virtual DbSet<EmploymentStatus> EmploymentStatuses { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<EmployeeProjectAllocation> EmployeeProjectAllocations { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    //public virtual DbSet<SystemRole> SystemRoles { get; set; }

    public virtual DbSet<ApplicationUser> Users { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(Employee.EmployeeConfiguration).Assembly);
    //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeProjectAllocation.EmployeeProjectsAssignedConfiguration).Assembly);
    //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(SystemRole.SystemRoleConfiguration).Assembly);
    //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(User.UserConfiguration).Assembly);



    //    OnModelCreatingPartial(modelBuilder);

    //}
    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var insertedEntries = this.ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Added)
            .Select(x => x.Entity);
        foreach(var insertedEntry in insertedEntries)
        {
            //If the inserted object is an Auditable. 
            if(insertedEntry is AuditableFields auditableEntity)
            {
                auditableEntity.CreatedAt = DateTime.UtcNow;
                auditableEntity.UpdatedAt = DateTime.UtcNow;
                
                auditableEntity.CreatedBy = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
                auditableEntity.UpdatedBy = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
            }
        }

        var modifiedEntries = this.ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Modified)
            .Select(x => x.Entity);

        foreach (var modifiedEntry in modifiedEntries)
        {
            //If the inserted object is an Auditable. 
            
            if (modifiedEntry is AuditableFields auditableEntity)
            {
                auditableEntity.UpdatedAt = DateTime.UtcNow;
                auditableEntity.UpdatedBy = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }


    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=.\\;Database=HRIS_DB_REV;Trusted_Connection=True; Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Employee.EmployeeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeProjectAllocation.EmployeeProjectAllocationConfiguration).Assembly);

        modelBuilder.Entity<EmployeeAttendance>(entity =>
        {
            entity.ToTable("EmployeeAttendance");

            entity.Property(e => e.EmployeeAttendanceId).ValueGeneratedNever();
            entity.Property(e => e.AttendanceDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeAttendances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeAttendance_EmployeeId");
        });

        modelBuilder.Entity<EmployeeAttendanceLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmployeeAttendanceLog");

            entity.Property(e => e.Checkin).HasColumnType("datetime");
            entity.Property(e => e.Checkout).HasColumnType("datetime");
            entity.Property(e => e.Location).HasColumnType("datetime");

            entity.HasOne(d => d.EmployeeAttendance).WithMany()
                .HasForeignKey(d => d.EmployeeAttendanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeAttendanceLog_EmployeeAttendanceId");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeAttendanceLog_EmployeeId");
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.ToTable("EmployeeRole");

            entity.Property(e => e.EmployeeRoleId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeRoleAdditionalPermission>(entity =>
        {
            entity.ToTable("EmployeeRoleAdditionalPermission");

            entity.Property(e => e.EmployeeRoleAdditionalPermissionId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Permission)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.EmployeeRoleAdditionalPermissionNavigation).WithOne(p => p.EmployeeRoleAdditionalPermission)
                .HasForeignKey<EmployeeRoleAdditionalPermission>(d => d.EmployeeRoleAdditionalPermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeRoleAdditionalPermission_EmployeeId");
        });

        modelBuilder.Entity<EmployeeRolePermission>(entity =>
        {
            entity.ToTable("EmployeeRolePermission");

            entity.Property(e => e.EmployeeRolePermissionId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Permission)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.EmployeeRole).WithMany(p => p.EmployeeRolePermissions)
                .HasForeignKey(d => d.EmployeeRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeRolePermission_EmployeeRoleId");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.ProjectId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Priority)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeSkill>(entity =>
        {
            entity.ToTable("EmployeeSkill");

            entity.Property(e => e.EmployeeSkillId).ValueGeneratedNever();
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

            entity.Property(e => e.EmploymentStatusId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.ToTable("Job");

            entity.Property(e => e.JobId).ValueGeneratedNever();
            entity.Property(e => e.Classification)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Job_EmployeeId");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.ToTable("Skill");

            entity.Property(e => e.SkillId).ValueGeneratedNever();
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });
       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
