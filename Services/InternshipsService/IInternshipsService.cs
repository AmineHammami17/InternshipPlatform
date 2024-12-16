namespace InternshipPlatform.Services.InternshipsService
{
    public interface IInternshipsService
    {
        List<Internships> GetAllInternships();
        Internships GetInternship(int id);
        List<Internships> AddInternship(Internships internship);
        List<Internships> UpdateInternship(int id, Internships request);
        List<Internships> DeleteHero(int id, Internships request);
    }
}
