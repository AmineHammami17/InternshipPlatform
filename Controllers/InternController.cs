using AutoMapper;
using InternshipPlatform.Models;
using InternshipPlatform.Models.DTO;
using InternshipPlatform.Services.InternService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternshipPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInternService _internService;

        public InternController(IInternService internService, IMapper mapper)
        {
            _internService = internService;
            _mapper = mapper;
        }

        /// <summary>
        /// this method is used to retrieve a list of all interns.
        /// </summary>
        [HttpGet("GetAllInterns")]
        public async Task<ActionResult<List<InternDto>>> GetAllInterns()
        {
            
                var interns = await _internService.GetAllInterns();

                var internDtos = _mapper.Map<List<InternDto>>(interns);

                return Ok(internDtos);
            
        }

        [HttpGet("GetSingleIntern/{id}")]
        public async Task<ActionResult<InternDto>> GetSingleIntern(int id)
        {
            var intern = await _internService.GetSingleIntern(id);

            if (intern is null)
            {
                return NotFound("Sorry, Intern doesn't exist");
            }

            var internDto = _mapper.Map<InternDto>(intern);

            return Ok(internDto);
        }

        [HttpPost("AddIntern")]
        public async Task<ActionResult<InternDto>> AddIntern(InternDto internDto)
        {
            var intern = _mapper.Map<Intern>(internDto);

            var addedIntern = await _internService.AddIntern(intern);

            if (addedIntern is null)
            {
                return BadRequest("Failed to add the intern");
            }

            var addedInternDto = _mapper.Map<InternDto>(addedIntern);

            return Ok(addedInternDto);
        }

        [HttpPut("UpdateIntern/{id}")]
        public async Task<ActionResult<InternDto>> UpdateIntern(int id, InternDto requestDto)
        {
            var request = _mapper.Map<Intern>(requestDto);

            var updatedIntern = await _internService.UpdateIntern(id, request);

            if (updatedIntern is null)
            {
                return NotFound("Sorry, Intern doesn't exist");
            }

            var updatedInternDto = _mapper.Map<InternDto>(updatedIntern);

            return Ok(updatedInternDto);
        }

        [HttpDelete("DeleteIntern/{id}")]
        public async Task<ActionResult> DeleteIntern(int id)
        {
            var deletedIntern = await _internService.DeleteIntern(id);

            if (deletedIntern is null)
            {
                return NotFound("Sorry, Intern doesn't exist");
            }

            return NoContent();
        }
    }
}
