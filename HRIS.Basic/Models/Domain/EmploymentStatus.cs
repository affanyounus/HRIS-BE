using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmploymentStatus: AuditableFields
{
    [Key]
    public Guid EmploymentStatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
