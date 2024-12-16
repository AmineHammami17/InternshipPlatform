using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InternshipPlatform.Models
{
    [Index(nameof(Email),IsUnique = true)]
    [Index(nameof(Number), IsUnique = true)]

    public class Intern
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Number must be an 8-digit number.")]
        public int Number { get; set; }

        [Required]
        public string InternshipStatus { get; set; }


        public int InternshipID { get; set; }
        public int SupervisorID { get; set; }


        public Internships Internships { get; set; }
        public Supervisor Supervisor { get; set; }
        public List<Evaluation> Evaluations { get; set; }
        public InternshipProgress InternshipProg { get; set; }


    }
}
