using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InternshipPlatform.Models;
using InternshipPlatform.Models.DTO;
using InternshipPlatform.Services.EvaluationService;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;
        private readonly IMapper _mapper;

        public EvaluationController(IEvaluationService evaluationService, IMapper mapper)
        {
            _evaluationService = evaluationService;
            _mapper = mapper;
        }

        [HttpGet("GetAllEvaluations")]
        public async Task<ActionResult<List<EvaluationDto>>> GetAllEvaluations()
        {
            var evaluations = await _evaluationService.GetAllEvaluations();
            var evaluationDtos = _mapper.Map<List<EvaluationDto>>(evaluations);

            return evaluationDtos;
        }

        [HttpGet("GetSingleEvaluation/{id}")]
        public async Task<ActionResult<EvaluationDto>> GetSingleEvaluation(int id)
        {
            var evaluation = await _evaluationService.GetSingleEvaluation(id);
            if (evaluation is null)
            {
                return NotFound("Sorry, Evaluation doesn't exist");
            }

            var evaluationDto = _mapper.Map<EvaluationDto>(evaluation);
            return Ok(evaluationDto);
        }

        [HttpPost("AddEvaluation")]
        public async Task<ActionResult<List<EvaluationDto>>> AddEvaluation(EvaluationDto evaluationDto)
        {
            var evaluation = _mapper.Map<Evaluation>(evaluationDto);
            var result = await _evaluationService.AddEvaluation(evaluation);

            var resultDto = _mapper.Map<List<EvaluationDto>>(result);
            return Ok(resultDto);
        }

        [HttpPut("UpdateEvaluation/{id}")]
        public async Task<ActionResult<List<EvaluationDto>>> UpdateEvaluation(int id, EvaluationDto requestDto)
        {
            var request = _mapper.Map<Evaluation>(requestDto);
            var result = await _evaluationService.UpdateEvaluation(id, request);

            if (result is null)
            {
                return NotFound("Sorry, Evaluation doesn't exist");
            }

            var resultDto = _mapper.Map<List<EvaluationDto>>(result);
            return Ok(resultDto);
        }
        

  


        [HttpDelete("DeleteEvaluation/{id}")]
        public async Task<ActionResult<List<EvaluationDto>>> DeleteEvaluation(int id)
        {
            var result = await _evaluationService.DeleteEvaluation(id);

            if (result is null)
            {
                return NotFound("Sorry, Evaluation doesn't exist");
            }

            var resultDto = _mapper.Map<List<EvaluationDto>>(result);
            return Ok(resultDto);
        }
    }
}
