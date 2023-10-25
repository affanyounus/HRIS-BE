using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmployeeRolePermission
{
    public Guid EmployeeRolePermissionId { get; set; }

    public Guid EmployeeRoleId { get; set; }

    public string Permission { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public virtual EmployeeRole EmployeeRole { get; set; } = null!;
}
