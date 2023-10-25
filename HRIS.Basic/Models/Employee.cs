using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models;

public partial class Employee
{
    public long EmployeeId { get; set; }

    public long EmploymentStatusId { get; set; }

    public long EmployeeRoleId { get; set; }

    public long UserId { get; set; }

    public long JobId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Cnic { get; set; } = null!;

    public DateTime JoiningDate { get; set; }

    public string PersonalEmailAddress { get; set; } = null!;

    public string CompanyEmailAddress { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string State { get; set; } = null!;

    public string City { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long CreatedBy { get; set; }

    public long UpdatedBy { get; set; }

    public virtual EmployeeAttendance? EmployeeAttendance { get; set; }

    public virtual EmployeeRole EmployeeRole { get; set; } = null!;

    public virtual ICollection<EmployeeRoleAdditionalPermission> EmployeeRoleAdditionalPermissions { get; set; } = new List<EmployeeRoleAdditionalPermission>();

    public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();

    public virtual EmploymentStatus EmploymentStatus { get; set; } = null!;

    public virtual Job Job { get; set; } = null!;
}
