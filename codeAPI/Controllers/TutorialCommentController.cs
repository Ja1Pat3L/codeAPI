using AutoMapper;
using codeAPI.DTOs;
using codeAPI.Services;
using codeLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace codeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialCommentController : ControllerBase
    {
        private IcodeRepository _codeRepository;
        private readonly IMapper _mapper;
        public TutorialCommentController(IcodeRepository codeRepository, IMapper mapper)
        {
            _codeRepository = codeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/commentsfortutorial{tutorial_id}")]
        
        public async Task<IActionResult> GetTutorialComments(int tutorial_id)
        {
            var info = await _codeRepository.GetTutorialComments(tutorial_id);
                var result=_mapper.Map<IEnumerable<TutorialComment>>(info);
            return Ok (result);
     
        }

        [HttpPost("/api/newcommentfortutorial{}")]
        public async Task<ActionResult<TutorialCommentDto>> CreateTutorial(
         [FromBody] TutorialForCreateDto tutorial)
        {
            if (tutorial == null) return BadRequest();

            if (tutorial.TutorialDescription == tutorial.TutorialName)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name.");
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            /*   if (!await _cityInfoRepository.CityExists(cityId)) return NotFound();*/

            var finalTutorial = _mapper.Map<Tutorial>(tutorial);

            _codeRepository.AddTutorial(finalTutorial);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            var createdTutorial = _mapper.Map<TutorialDto>(finalTutorial);

            return CreatedAtAction("GetTutorialInfo", createdTutorial);
        }



    }

}
