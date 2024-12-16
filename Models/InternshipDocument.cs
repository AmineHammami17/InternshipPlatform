using System.ComponentModel.DataAnnotations.Schema;

namespace InternshipPlatform.Models
{
    public class InternshipDocument
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Accessibility { get; set; }
        public int InternshipsId { get; set; }
        public Internships Internships { get; set; }


    }
}
