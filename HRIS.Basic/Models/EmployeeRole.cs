using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models;

public partial class EmployeeRole
{
    public long EmployeeRoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long CreatedBy { get; set; }

    public long UpdatedBy { get; set; }

    public virtual EmployeeRolePermission? EmployeeRolePermission { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
