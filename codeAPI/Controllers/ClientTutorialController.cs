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

        #region INSTANCES

        private IcodeRepository _codeRepository;
        private Client finalclient;
        private readonly IMapper _mapper;

        #endregion

        #region CONSTRUCTOR
        public ClientTutorialController(IcodeRepository codeRepository, IMapper mapper)
        {
            _codeRepository = codeRepository;
            _mapper = mapper;
        }
        #endregion

        #region GET CLIENT TUTORIALS

        [HttpGet]
        [Route("/api/clientTutorials{client_id}")]
        public async Task<IActionResult> GetClientTutorialInfo(int client_id)
        {
            var clientTutorialInfo = await _codeRepository.GetClientTutorials(client_id);
            if (clientTutorialInfo == null)
                return NotFound();

            var result = _mapper.Map<IEnumerable<ClientTutorial>>(clientTutorialInfo);
            return Ok(result);

        }
        #endregion

        #region POST CLIENT TUTORIAL
        [HttpPost("/api/newClientTutorial")]

        public async Task<ActionResult<ClientTutorialDto>> AddClientTutorial(
            [FromBody]ClientTutorialForCreateDto client_tutorial
            
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

            return Ok(createdClientTutorial);

        }

        #endregion

        #region DELETE CLIENT TUTORIAL
        
            [HttpDelete("api/clienttutorial/{ClientId}/{TutorialId}")]
            public async Task<IActionResult> DeleteTutorial(int ClientId, int TutorialId)
            {
               
                var tutorialEntity = await _codeRepository.GetClientTutorial(ClientId, TutorialId);
                if (tutorialEntity == null) return NotFound();


                _codeRepository.DeleteClientTutorial(tutorialEntity);

                if (!await _codeRepository.Save())
                {
                    return StatusCode(500, "A problem happened while handling your request");
                }

                return NoContent();

            }
        #endregion
    }
}