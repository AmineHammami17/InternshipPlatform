using InternshipPlatform.Data;
using InternshipPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipPlatform.Services.EvaluationService
{
    public class EvaluationService : IEvaluationService
    {
        private readonly DataContext _context;

        public EvaluationService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Evaluation>?> GetAllEvaluations()
        {
            var evaluations = await _context.Evaluations.ToListAsync();
            return evaluations;
        }

        public async Task<Evaluation?> GetSingleEvaluation(int id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            return evaluation;
        }

        public async Task<List<Evaluation>?> AddEvaluation(Evaluation evaluation)
        {
            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync();
            return await _context.Evaluations.ToListAsync();
        }

        public async Task<List<Evaluation>?> UpdateEvaluation(int id, Evaluation request)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation is null)
            {
                return null;
            }

            evaluation.Content = request.Content;
            evaluation.Rating = request.Rating;

            await _context.SaveChangesAsync();

            return await _context.Evaluations.ToListAsync();
        }

        public async Task<List<Evaluation>?> DeleteEvaluation(int id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation is null)
            {
                return null;
            }

            _context.Evaluations.Remove(evaluation);
            await _context.SaveChangesAsync();

            return await _context.Evaluations.ToListAsync();
        }
    }
}
