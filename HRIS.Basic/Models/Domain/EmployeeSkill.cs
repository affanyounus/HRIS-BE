using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class EmployeeSkill: AuditableFields
{
    [Key]
    public Guid EmployeeSkillId { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid SkillId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
