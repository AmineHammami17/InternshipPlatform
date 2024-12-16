using InternshipPlatform.Data;
using InternshipPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipPlatform.Services.InternService
{
    public class InternService : IInternService
    {
        private readonly DataContext _context;

        public InternService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Intern>?> GetAllInterns()
        {
            var interns = await _context.Interns.ToListAsync();
            return interns;
        }

        public async Task<Intern?> GetSingleIntern(int id)
        {
            var intern = await _context.Interns.FindAsync(id);
            return intern;
        }

        public async Task<List<Intern>?> AddIntern(Intern intern)
        {
            _context.Interns.Add(intern);
            await _context.SaveChangesAsync();
            return await _context.Interns.ToListAsync();
        }

        public async Task<List<Intern>?> UpdateIntern(int id, Intern request)
        {
            var intern = await _context.Interns.FindAsync(id);
            if (intern is null)
            {
                return null;
            }

            intern.Name = request.Name;
            intern.Email = request.Email;
            intern.Number = request.Number;
            intern.InternshipStatus = request.InternshipStatus;

            await _context.SaveChangesAsync();

            return await _context.Interns.ToListAsync();
        }

        public async Task<List<Intern>?> DeleteIntern(int id)
        {
            var intern = await _context.Interns.FindAsync(id);
            if (intern is null)
            {
                return null;
            }

            _context.Interns.Remove(intern);
            await _context.SaveChangesAsync();

            return await _context.Interns.ToListAsync();
        }
    }
}
