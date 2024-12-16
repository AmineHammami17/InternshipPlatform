using InternshipPlatform.Data;
using InternshipPlatform.Models;
using InternshipPlatform.Models.DTO;

namespace InternshipPlatform.Services.DocumentService
{
    public class DocumentService : IDocumentService
    {
        private static List<InternshipDocument> Documents = new List<InternshipDocument>
            {
                new InternshipDocument
                {

                }
            };
        private readonly DataContext _context;
        public DocumentService(DataContext context)
        {
            _context = context;

        }

        public async Task<List<InternshipDocument>?> AddDocument(InternshipDocument document)
        {
            _context.InternshipDocuments.Add(document);
            await _context.SaveChangesAsync();
            return await _context.InternshipDocuments.ToListAsync();
        }

        public async Task<List<InternshipDocument>?> DeleteDocument(int id)
        {
            var document = await _context.InternshipDocuments.FindAsync(id);
            if (document is null)
            {
                return null;
            }

            _context.InternshipDocuments.Remove(document);
            await _context.SaveChangesAsync();

            return await _context.InternshipDocuments.ToListAsync();
        }

        public async Task<List<InternshipDocumentDto>?> GetAllDocuments()
        {
            var documents = await _context.InternshipDocuments
                .Select(document => new InternshipDocumentDto
                {
                    Id = document.Id,
                    Title = document.Title,
                    Accessibility = document.Accessibility,
                    InternshipsId = document.InternshipsId
                })
                .ToListAsync();

            return documents;
        }
        public async Task<InternshipDocument?> GetSingleDocument(int id)
        {
            var document = await _context.InternshipDocuments.FindAsync(id);
            if (document is null)
            {
                return null;
            }
            return document;
        }

        public async Task<List<InternshipDocument>?> UpdateDocument(int id, InternshipDocument request)
        {
            var document = await _context.InternshipDocuments.FindAsync(id);
            if (document is null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                document.Title = request.Title;
            }

            if (!string.IsNullOrWhiteSpace(request.Accessibility))
            {
                document.Accessibility = request.Accessibility;
            }
            await _context.SaveChangesAsync();

            return await _context.InternshipDocuments.ToListAsync();

        }
    }
}
