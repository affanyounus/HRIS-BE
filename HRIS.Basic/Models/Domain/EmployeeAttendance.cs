using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmployeeAttendance: AuditableFields
{
    [Key]
    public Guid EmployeeAttendanceId { get; set; }

    public Guid EmployeeId { get; set; }

    public DateTime AttendanceDate { get; set; }

    public int TotalHours { get; set; }

    public string Status { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
