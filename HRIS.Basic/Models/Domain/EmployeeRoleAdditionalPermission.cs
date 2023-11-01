using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmployeeRoleAdditionalPermission: AuditableFields
{
    [Key]
    public Guid EmployeeRoleAdditionalPermissionId { get; set; }

    public Guid EmployeeId { get; set; }

    public string Permission { get; set; } = null!;

    public virtual Employee EmployeeRoleAdditionalPermissionNavigation { get; set; } = null!;
}
