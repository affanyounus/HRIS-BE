namespace HRIS.Basic.Models.DTO.User
{
    public class UserRequestDTO
    {
        [Required]
        [MinLength(5)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(5)]
        public string LastName { get; set; } = null!;

        [Required]
        [MinLength(10)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
        
        [Required]
        public bool IsActive { get; set; }

    }
}
