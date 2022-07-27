using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using codeAPI.DTOs;
using codeAPI.Services;
using codeLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace codeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientTutorialController : ControllerBase
    {


        private IcodeRepository _codeRepository;
        private readonly IMapper _mapper;

        public ClientTutorialController(IcodeRepository codeRepository, IMapper mapper)
        {
            _codeRepository = codeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/clientTutorials{client_id}")]
        public async Task<IActionResult> GetClientTutorialInfo(int client_id)
        {
            var clientTutorialInfo = await _codeRepository.GetClientTutorials(client_id);
            if (clientTutorialInfo == null)
                return NotFound();

            var result = _mapper.Map<IEnumerable<ClientTutorialDto>>(clientTutorialInfo);
            return Ok(result);

        }

        [HttpPost("/api/newClientTutorial")]

        public async Task<ActionResult<ClientTutorialDto>> AddClientTutorial(
            [FromBody]ClientTutorialDto client_tutorial
            
            ) {

            if (client_tutorial == null) return BadRequest();

         
            if (!ModelState.IsValid) return BadRequest(ModelState);

            /*   if (!await _cityInfoRepository.CityExists(cityId)) return NotFound();*/

            var finalTutorial = _mapper.Map<ClientTutorial>(client_tutorial);

            _codeRepository.AddClientTutorial(finalTutorial);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            var createdClientTutorial = _mapper.Map<ClientTutorialDto>(finalTutorial);

            return CreatedAtAction("GetTutorialInfo", createdClientTutorial);

        }

    /*    [HttpPut("{id}/updatetutorial")]
        public async Task<ActionResult> UpdateTutorial(int id, [FromBody] TutorialForUpdateDto tutorial)
        {
            if (tutorial == null) return BadRequest();

            if (tutorial.TutorialDescription == tutorial.TutorialName)
            {
                ModelState.AddModelError(key: "Description", errorMessage: "The provided description should be different from the name.");
            }

            if (!ModelState.IsValid) return BadRequest();

            if (!await _codeRepository.TutorialExists(id)) return NotFound();

            var tutorialEntity = await _codeRepository.GetTutorialById(id);
            if (tutorial == null) return NotFound();

            _mapper.Map(tutorial, tutorialEntity);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem ocurred while handling your request");
            }

            return NoContent();
        }


        [HttpDelete("api/tutorial/{TutorialId}")]
        public async Task<IActionResult> DeleteTutorial(int TutorialId)
        {
            if (!await _codeRepository.TutorialExists(TutorialId)) return NotFound();

            var tutorialEntity = await _codeRepository.GetTutorialById(TutorialId);
            if (tutorialEntity == null) return NotFound();

            //_cityInfoRepository.DeletePointOfInterest(pointOfInterestEntity);

            _codeRepository.DeleteTutorial(tutorialEntity);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();

        }*/

    }
}