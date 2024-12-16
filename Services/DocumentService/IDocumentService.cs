using InternshipPlatform.Models.DTO;

namespace InternshipPlatform.Services.DocumentService
{
    public interface IDocumentService
    {
        Task<List<InternshipDocumentDto>?> GetAllDocuments();

        Task<InternshipDocument?> GetSingleDocument(int id);

        Task<List<InternshipDocument>?> AddDocument(InternshipDocument document);

        Task<List<InternshipDocument>?> UpdateDocument(int id, InternshipDocument request);

        Task<List<InternshipDocument>?> DeleteDocument(int id);

    }
}
