using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models;

public partial class EmployeeRoleAdditionalPermission
{
    public long EmployeeRoleAdditionalPermissionId { get; set; }

    public long EmployeeId { get; set; }

    public string Permission { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long CreatedBy { get; set; }

    public long UpdatedBy { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
