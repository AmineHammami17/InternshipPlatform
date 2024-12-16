using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InternshipPlatform.Models
{
    [Index(nameof(Title), IsUnique = true)]
    [Index(nameof(Description), IsUnique = true)]


    public class Internships
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Duration { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public int NumberInterns { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;

        public List<Intern> Interns { get; set; }

        public List<InternshipDocument> InternshipDocuments { get; set; }

        public InternshipProgress InternshipProg { get; set; }






    }
}
