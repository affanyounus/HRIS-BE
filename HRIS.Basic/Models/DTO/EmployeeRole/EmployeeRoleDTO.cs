using HRIS.Basic.Models.Domain;
using HRIS.Basic.Models.DTO.EmployeeRolePermission;

namespace HRIS.Basic.Models.DTO.EmployeeRole
{
    public class EmployeeRoleDTO
    {
        public Guid EmployeeRoleId { get; set; }

        public string RoleName { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual ICollection<EmployeeRolePermissionDTO> EmployeeRolePermissions { get; set; } = new List<EmployeeRolePermissionDTO>();

    }
}
