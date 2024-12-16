using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InternshipPlatform.Models
{
    [Index(nameof(Number), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]

    public class Supervisor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Number must be an 8-digit number.")]
        public int Number { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public int InternsAssigned { get; set; }
        public string SupervisorStatus { get; set; }
        public List<Intern> Interns { get; set; }
        public List<Evaluation> Evaluations { get; set; }

    }
}
