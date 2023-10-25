using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmploymentStatus
{
    public Guid EmploymentStatusId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
