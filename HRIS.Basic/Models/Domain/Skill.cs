using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class Skill: AuditableFields
{
    [Key]
    public Guid SkillId { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
}
