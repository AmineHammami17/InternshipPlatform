namespace InternshipPlatform.Models.DTO
{
    public class EvaluationDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int InternID { get; set; }
        public int SupervisorID { get; set; }
    }
}
