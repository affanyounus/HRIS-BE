using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class Job: AuditableFields
{
    [Key]
    public Guid JobId { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid ReportTo { get; set; }

    public string Title { get; set; } = null!;

    public string Classification { get; set; } = null!;

    public bool IsBillable { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
