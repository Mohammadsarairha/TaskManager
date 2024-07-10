using Microsoft.AspNetCore.Identity;

namespace Domain.Dto
{
    public class AddProjectTaskDto
    {
        public string? TaskCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Note { get; set; }
        public int? ProjectId { get; set; } = null;
        public string? UserId { get; set; } = string.Empty;
        public int? TaskTypeId { get; set; } = null;
    }
}
