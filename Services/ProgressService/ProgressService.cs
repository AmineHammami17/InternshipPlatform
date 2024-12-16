using InternshipPlatform.Data;
using InternshipPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipPlatform.Services.ProgressService
{
    public class ProgressService : IProgressService
    {
        private readonly DataContext _context;

        public ProgressService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<InternshipProgress>?> GetAllProgress()
        {
            var progressList = await _context.InternshipProgress.ToListAsync();
            return progressList;
        }

        public async Task<InternshipProgress?> GetSingleProgress(int id)
        {
            var progress = await _context.InternshipProgress.FindAsync(id);
            return progress;
        }

        public async Task<InternshipProgress?> AddProgress(InternshipProgress progress)
        {
            _context.InternshipProgress.Add(progress);
            await _context.SaveChangesAsync();
            return progress;
        }

        public async Task<List<InternshipProgress>?> UpdateProgress(int id, InternshipProgress request)
        {
            var progress = await _context.InternshipProgress.FindAsync(id);
            if (progress is null)
            {
                return null;
            }

            await _context.SaveChangesAsync();

            return await _context.InternshipProgress.ToListAsync();
        }

        public async Task<List<InternshipProgress>?> DeleteProgress(int id)
        {
            var progress = await _context.InternshipProgress.FindAsync(id);
            if (progress is null)
            {
                return null;
            }

            _context.InternshipProgress.Remove(progress);
            await _context.SaveChangesAsync();

            return await _context.InternshipProgress.ToListAsync();
        }
    }
}
