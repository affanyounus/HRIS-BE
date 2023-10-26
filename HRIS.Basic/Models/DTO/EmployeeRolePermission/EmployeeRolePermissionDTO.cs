namespace HRIS.Basic.Models.DTO.EmployeeRolePermission
{
    public class EmployeeRolePermissionDTO
    {
        public Guid EmployeeRolePermissionId { get; set; }

        public Guid EmployeeRoleId { get; set; }

        public string Permission { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }

    }
}
