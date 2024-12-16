using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InternshipPlatform.Models;
using InternshipPlatform.Models.DTO;
using InternshipPlatform.Services.ProgressService;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressService _progressService;
        private readonly IMapper _mapper;

        public ProgressController(IProgressService progressService, IMapper mapper)
        {
            _progressService = progressService;
            _mapper = mapper;
        }

        [HttpGet("GetAllProgress")]
        public async Task<ActionResult<List<ProgressDto>>> GetAllProgress()
        {
            var progressList = await _progressService.GetAllProgress();
            var progressDtos = _mapper.Map<List<ProgressDto>>(progressList);

            return progressDtos;
        }

        [HttpGet("GetSingleProgress/{id}")]
        public async Task<ActionResult<ProgressDto>> GetSingleProgress(int id)
        {
            var progress = await _progressService.GetSingleProgress(id);
            if (progress is null)
            {
                return NotFound("Sorry, Progress doesn't exist");
            }

            var progressDto = _mapper.Map<ProgressDto>(progress);
            return Ok(progressDto);
        }

        [HttpPost("AddProgress")]
        public async Task<ActionResult<ProgressDto>> AddProgress(ProgressDto progressDto)
        {
            var progress = _mapper.Map<InternshipProgress>(progressDto);
            var addedProgress = await _progressService.AddProgress(progress);

            if (addedProgress is null)
            {
                return BadRequest("Failed to add the progress");
            }

            var addedProgressDto = _mapper.Map<ProgressDto>(addedProgress);
            return Ok(addedProgressDto);
        }

        [HttpPut("UpdateProgress/{id}")]
        public async Task<ActionResult<ProgressDto>> UpdateProgress(int id, ProgressDto requestDto)
        {
            var request = _mapper.Map<InternshipProgress>(requestDto);
            var updatedProgress = await _progressService.UpdateProgress(id, request);

            if (updatedProgress is null)
            {
                return NotFound("Sorry, Progress doesn't exist");
            }

            var updatedProgressDto = _mapper.Map<ProgressDto>(updatedProgress);
            return Ok(updatedProgressDto);
        }

        [HttpDelete("DeleteProgress/{id}")]
        public async Task<ActionResult> DeleteProgress(int id)
        {
            var deletedProgress = await _progressService.DeleteProgress(id);

            if (deletedProgress is null)
            {
                return NotFound("Sorry, Progress doesn't exist");
            }

            return NoContent();
        }
    }
}
