using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternshipPlatform.Models
{
    public class InternshipProgress
    {
        public int Id { get; set; }
        public string CompletedTasks { get; set; }
        public string SkillsDeveloped { get; set; }
        public int InternshipID { get; set; }
        public int InternID { get; set; }
        public Internships Internship { get; set; }
        public Intern Intern { get; set; }

    }
}
