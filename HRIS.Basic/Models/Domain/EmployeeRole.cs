using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmployeeRole
{
    public Guid EmployeeRoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public virtual ICollection<EmployeeRolePermission> EmployeeRolePermissions { get; set; } = new List<EmployeeRolePermission>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
