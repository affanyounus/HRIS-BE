using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models;

public partial class EmployeeSkill
{
    public long EmployeeSkillId { get; set; }

    public long EmployeeId { get; set; }

    public long SkillId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long CreatedBy { get; set; }

    public long UpdatedBy { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
