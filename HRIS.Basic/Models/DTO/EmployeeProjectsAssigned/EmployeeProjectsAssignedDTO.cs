using HRIS.Basic.Models.DTO.Employee;
using HRIS.Basic.Models.DTO.Project;

namespace HRIS.Basic.Models.DTO.EmployeeProjectsAssigned
{
    public class EmployeeProjectsAssignedDTO
    {
        public Guid EmployeeProjectAssignedId { get; set; }

        public Guid ProjectId { get; set; }

        public Guid EmployeeId { get; set; }

        public bool IsBillable { get; set; }

        public double BillableHoursAssigned { get; set; }

        public double BillableHoursWorked { get; set; }

        public double NonBillableHoursAssigned { get; set; }

        public double NonBillableHoursWorked { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual ProjectDTO Project { get; set; } = null!;

        public virtual EmployeeDTO Employee { get; set; } = null!;
    }
}
