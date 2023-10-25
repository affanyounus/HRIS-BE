using System;
using System.Collections.Generic;

namespace HRIS.Basic.Models.Domain;

public partial class User
{
    public Guid UserId { get; set; }

    public Guid SystemRoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public virtual SystemRole SystemRole { get; set; } = null!;
}
