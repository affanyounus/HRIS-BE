using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class Project
{
    public Guid ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Priority { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public virtual ICollection<EmployeeProjectsAssigned> EmployeeProjectsAssigneds { get; set; } = new List<EmployeeProjectsAssigned>();
}
