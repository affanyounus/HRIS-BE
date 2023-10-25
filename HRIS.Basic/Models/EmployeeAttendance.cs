using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models;

public partial class EmployeeAttendance
{
    public long EmployeeAttendanceId { get; set; }

    public long EmployeeId { get; set; }

    public DateTime AttendanceDate { get; set; }

    public int TotalHours { get; set; }

    public string Status { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public virtual Employee EmployeeAttendanceNavigation { get; set; } = null!;
}
