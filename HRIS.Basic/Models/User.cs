using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models;

public partial class User
{
    public long UserId { get; set; }

    public long SystemRoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime CreatedBy { get; set; }

    public DateTime UpdatedBy { get; set; }

    public virtual SystemRole SystemRole { get; set; } = null!;
}
