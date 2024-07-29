
namespace Domain.Dto
{
    public class AddProjectDto
    {
        public string? ProjectName { get; set; }
        public string? ProjectCode { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? ParentProjectId { get; set; } = null;
        public string? ProjectNote { get; set; }
    }
}
