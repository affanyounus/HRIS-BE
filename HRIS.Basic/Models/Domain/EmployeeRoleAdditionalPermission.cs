using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmployeeRoleAdditionalPermission
{
    public Guid EmployeeRoleAdditionalPermissionId { get; set; }

    public Guid EmployeeId { get; set; }

    public string Permission { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public virtual Employee EmployeeRoleAdditionalPermissionNavigation { get; set; } = null!;
}
