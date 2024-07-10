using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class ProjectTask
    {
        public int? Id { get; set; }
        public string? TaskCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Note { get; set; }
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        public int? TaskTypeId { get; set; }
        public TaskType? TaskType { get; set; }
    }
}
