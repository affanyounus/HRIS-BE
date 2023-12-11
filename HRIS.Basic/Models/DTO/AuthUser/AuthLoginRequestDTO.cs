namespace HRIS.Basic.Models.DTO.AuthUser
{
    public class AuthLoginRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
