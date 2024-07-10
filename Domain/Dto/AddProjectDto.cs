
namespace Domain.Dto
{
    public class AddProjectDto
    {
        public string? ProjectName { get; set; }
        public string? ProjectCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ParentProjectId { get; set; } = null;
        public string? ProjectNote { get; set; }
    }
}
