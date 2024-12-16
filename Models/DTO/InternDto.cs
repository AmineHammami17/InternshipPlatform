using System.ComponentModel.DataAnnotations;

namespace InternshipPlatform.Models.DTO
{
    public class InternDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }
        public string InternshipStatus { get; set; }
        public int InternshipID { get; set; }
        public int SupervisorID { get; set; }


    }
}
