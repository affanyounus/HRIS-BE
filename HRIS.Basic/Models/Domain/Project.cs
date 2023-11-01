using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class Project: AuditableFields
{
    [Key]
    public Guid ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Priority { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<EmployeeProjectAllocation> EmployeeProjectsAllocations { get; set; } = new List<EmployeeProjectAllocation>();
}
