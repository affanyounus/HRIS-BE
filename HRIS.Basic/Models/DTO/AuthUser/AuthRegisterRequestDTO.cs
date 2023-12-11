namespace HRIS.Basic.Models.DTO.AuthUser
{
    public class AuthRegisterRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required] public string FullName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum Characters should be 6.")]
        public string Password { get; set; }
    }
}
