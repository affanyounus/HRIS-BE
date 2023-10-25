using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class Skill
{
    public Guid SkillId { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
}
