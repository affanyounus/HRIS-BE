namespace HRIS.Basic.Models.DTO.Project
{
    public class ProjectDTO
    {
        public Guid ProjectId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Priority { get; set; } = null!;

        public string Status { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }

    }
}
