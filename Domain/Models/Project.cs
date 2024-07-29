using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Project
    {
        public int? ID { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectCode { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? ParentProjectId { get; set; }
        [JsonIgnore]
        public Project? ParentProject { get; set; }
        public ICollection<Project>? ChildProjects { get; set; }
        public string? ProjectNote { get; set; } = string.Empty;
    }
}
