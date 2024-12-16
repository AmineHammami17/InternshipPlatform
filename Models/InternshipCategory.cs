using System.ComponentModel.DataAnnotations;

namespace InternshipPlatform.Models
{
    public class InternshipCategory
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string Description { get; set; }



    }
}
