namespace InternshipPlatform.Services.InternService
{
    public interface IInternService
    {
        Task<List<Intern>?> GetAllInterns();
        Task<Intern?> GetSingleIntern(int id);
        Task<List<Intern>?> AddIntern(Intern intern);
        Task<List<Intern>?> UpdateIntern(int id, Intern request);
        Task<List<Intern>?> DeleteIntern(int id);
    }
}
