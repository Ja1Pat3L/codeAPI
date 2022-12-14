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
    public class TutorialController : ControllerBase
    {
        /*Instances Created for Repository (codeRepository) and Auto Mapper (IMapper)*/
        #region INSTANCES
        private IcodeRepository _codeRepository;
        private readonly IMapper _mapper;
        #endregion

        /*Class Constructor with above Instances as parameters*/
        #region CONSTRUCTOR
        public TutorialController(IcodeRepository codeRepository, IMapper mapper)
        {
            _codeRepository = codeRepository;
            _mapper = mapper;
        }
        #endregion

        /*Method- Getting List of Tutorials or Tutorial using Tutorial Is*/
        #region GET TUTORIAL
        [HttpGet]
        [Route("/api/tutorials")]
        public async Task<IActionResult> GetTutorialInfo()
        {
            var tutorialInfo = await _codeRepository.GetTutorialInfo();
            var result = _mapper.Map<IEnumerable<TutorialDto>>(tutorialInfo);
            return Ok(result);
        }

        [HttpGet("{id}")]
      //  [Route("/api/tutorial")]
        public async Task<IActionResult> GetTutorialInfoById(int id)
        {

            var tutorialInfo = await _codeRepository.GetTutorialById(id);
            if(tutorialInfo == null)    
                return NotFound();
           
            var result = _mapper.Map<TutorialDto>(tutorialInfo);
            return Ok(result);
        }
        #endregion

        /*Method- Creating Tutorial*/
        #region POST TUTORIAL
        [HttpPost("/api/newTutorial")]
        public async Task<ActionResult<TutorialDto>> CreateTutorial(
         [FromBody] TutorialForCreateDto tutorial)
        {
            if (tutorial == null) return BadRequest();

            if (tutorial.TutorialDescription==tutorial.TutorialName)
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

            var createdTutorial= _mapper.Map<TutorialDto>(finalTutorial);

            return CreatedAtAction("GetTutorialInfo", createdTutorial);
        }
        #endregion

        /*Method- Updating Tutorial using Tutorial Id */
        #region PUT TUTORIAL

        [HttpPut("{id}/updatetutorial")]
        public async Task<ActionResult> UpdateTutorial( int id, [FromBody] TutorialForUpdateDto tutorial)
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
        #endregion

        /*Method- Deleting Tutorial using Tutorial Id*/
        #region DELETE TUTORIAL

        [HttpDelete("api/tutorial/{TutorialId}")]
        public async Task<IActionResult> DeleteTutorial( int TutorialId)
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

        }
        #endregion
    }
}
