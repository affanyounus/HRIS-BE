using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmployeeRolePermission: AuditableFields
{
    [Key]
    public Guid EmployeeRolePermissionId { get; set; }

    public Guid EmployeeRoleId { get; set; }

    public string Permission { get; set; } = null!;

    public virtual EmployeeRole EmployeeRole { get; set; } = null!;
}
