using InternshipPlatform.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternshipPlatform.Services.ProgressService
{
    public interface IProgressService
    {
        Task<List<InternshipProgress>?> GetAllProgress();

        Task<InternshipProgress?> GetSingleProgress(int id);

        Task<InternshipProgress?> AddProgress(InternshipProgress progress);

        Task<List<InternshipProgress>?> UpdateProgress(int id, InternshipProgress request);

        Task<List<InternshipProgress>?> DeleteProgress(int id);
    }
}
