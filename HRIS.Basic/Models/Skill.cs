using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models;

public partial class Skill
{
    public long SkillId { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
}
