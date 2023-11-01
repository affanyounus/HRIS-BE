using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmployeeAttendanceLog
{
    [Key]
    public Guid EmployeeAttendanceLogId { get; set; }

    public Guid EmployeeAttendanceId { get; set; }

    public Guid EmployeeId { get; set; }

    public DateTime Checkin { get; set; }

    public DateTime? Checkout { get; set; }

    public DateTime Location { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual EmployeeAttendance EmployeeAttendance { get; set; } = null!;
}
