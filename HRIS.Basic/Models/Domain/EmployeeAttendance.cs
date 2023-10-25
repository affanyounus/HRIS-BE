using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmployeeAttendance
{
    public Guid EmployeeAttendanceId { get; set; }

    public Guid EmployeeId { get; set; }

    public DateTime AttendanceDate { get; set; }

    public int TotalHours { get; set; }

    public string Status { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
