using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmployeeRole: AuditableFields
{
    [Key]
    public Guid EmployeeRoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<EmployeeRolePermission> EmployeeRolePermissions { get; set; } = new List<EmployeeRolePermission>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
