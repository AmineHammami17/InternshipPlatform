using System.ComponentModel.DataAnnotations;

namespace InternshipPlatform.Models
{
    public class Evaluation
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int Rating { get; set; }

        public int InternID { get; set; }
        public int SupervisorID { get; set; }
        public Intern Intern { get; set; }
        public Supervisor Supervisor { get; set; }

    }
}
