using System.ComponentModel.DataAnnotations;

namespace InternshipPlatform.Models.DTO
{
    public class InternshipDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int NumberInterns { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
