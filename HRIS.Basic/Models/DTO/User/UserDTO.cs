namespace HRIS.Basic.Models.DTO.User
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public Guid UserName { get; set; }

        public string NormalizedUserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string NormalizedEmail { get; set; } = null!;
        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; } = null!;
        public string SecurityStamp { get; set; } = null!;
        public string ConcurrencyStamp { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        //public Guid CreatedBy { get; set; }

        //public Guid UpdatedBy { get; set; }

    }
}
