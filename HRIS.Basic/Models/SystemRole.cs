using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models;

public partial class SystemRole
{
    public long SystemRoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long CreatedBy { get; set; }

    public long UpdatedBy { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
