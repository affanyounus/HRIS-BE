namespace HRIS.Basic.Models.DTO.Employee
{
    public class EmployeeRequestDTO
    {

        public Guid UserId { get; set; }

        public Guid JobId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Cnic { get; set; } = null!;

        public DateTime JoiningDate { get; set; }

        public string PersonalEmailAddress { get; set; } = null!;

        public string CompanyEmailAddress { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string State { get; set; } = null!;

        public string City { get; set; } = null!;
    }
}
