using AutoMapper;
using InternshipPlatform.Models.DTO;
using InternshipPlatform.Services.CategoryService;
using InternshipPlatform.Services.DocumentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatform.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }


        [HttpGet("GetAllDocuments")]
        public async Task<ActionResult<List<InternshipDocumentDto>>> GetAllDocuments()
        {
            var documents = await _documentService.GetAllDocuments();
            var documentDtos = _mapper.Map<List<InternshipDocumentDto>>(documents); 
            return documentDtos;
        }

        [HttpGet("GetSingleDocument/{id}")]
        public async Task<ActionResult<InternshipDocumentDto>> GetSingleDocument(int id)
        {
            var document = await _documentService.GetSingleDocument(id);

            if (document is null)
            {
                return NotFound("Sorry, Document doesn't exist");
            }

            var documentDto = _mapper.Map<InternshipDocumentDto>(document);

            return Ok(documentDto);
        }
        [HttpPost("AddDocument")]
        public async Task<ActionResult<InternshipDocumentDto>> AddDocument(InternshipDocumentDto documentDto)
        {
            var document = _mapper.Map<InternshipDocument>(documentDto);

            var addedDocument = await _documentService.AddDocument(document);

            if (addedDocument is null)
            {
                return BadRequest("Failed to add the document");
            }

            var addedDocumentDto = _mapper.Map<InternshipDocumentDto>(addedDocument);

            return Ok(addedDocumentDto);
        }
        [HttpPut("UpdateDocument/{id}")]
        public async Task<ActionResult<InternshipDocumentDto>> UpdateDocument(int id, InternshipDocumentDto requestDto)
        {
            var request = _mapper.Map<InternshipDocument>(requestDto);

            var updatedDocument = await _documentService.UpdateDocument(id, request);

            if (updatedDocument is null)
            {
                return NotFound("Sorry, Document doesn't exist");
            }

            var updatedDocumentDto = _mapper.Map<InternshipDocumentDto>(updatedDocument);

            return Ok(updatedDocumentDto);
        }

        [HttpDelete("DeleteDocument/{id}")]
        public async Task<ActionResult> DeleteDocument(int id)
        {
            var deletedDocument = await _documentService.DeleteDocument(id);

            if (deletedDocument is null)
            {
                return NotFound("Sorry, Document doesn't exist");
            }

            return NoContent();
        }
    }
}
