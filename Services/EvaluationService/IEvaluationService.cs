using InternshipPlatform.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternshipPlatform.Services.EvaluationService
{
    public interface IEvaluationService
    {
        Task<List<Evaluation>?> GetAllEvaluations();
        Task<Evaluation?> GetSingleEvaluation(int id);
        Task<List<Evaluation>?> AddEvaluation(Evaluation evaluation);
        Task<List<Evaluation>?> UpdateEvaluation(int id, Evaluation request);
        Task<List<Evaluation>?> DeleteEvaluation(int id);
    }
}
