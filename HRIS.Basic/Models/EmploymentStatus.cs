using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models;

public partial class EmploymentStatus
{
    public long EmploymentStatusId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long CreatedBy { get; set; }

    public long UpdatedBy { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Job? Job { get; set; }
}
