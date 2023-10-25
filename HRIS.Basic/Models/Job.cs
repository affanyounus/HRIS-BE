using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models;

public partial class Job
{
    public long JobId { get; set; }

    public long ReportTo { get; set; }

    public string Title { get; set; } = null!;

    public string Classification { get; set; } = null!;

    public bool IsBillable { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long CreatedBy { get; set; }

    public long UpdatedBy { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual EmploymentStatus JobNavigation { get; set; } = null!;
}
