using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models;

public partial class EmployeeRolePermission
{
    public long EmployeeRolePermissionId { get; set; }

    public long EmployeeRoleId { get; set; }

    public string Permission { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long CreatedBy { get; set; }

    public long UpdatedBy { get; set; }

    public virtual EmployeeRole EmployeeRolePermissionNavigation { get; set; } = null!;
}
