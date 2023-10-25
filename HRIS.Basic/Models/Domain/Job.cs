using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class Job
{
    public Guid JobId { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid ReportTo { get; set; }

    public string Title { get; set; } = null!;

    public string Classification { get; set; } = null!;

    public bool IsBillable { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
