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
    public class ClientController : ControllerBase
    {
        private IcodeRepository _codeRepository;
        private Client finalclient;
        private readonly IMapper _mapper;

        public ClientController(IcodeRepository codeRepository, IMapper mapper)
        {
            _codeRepository = codeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/clients")]
        public async Task<IActionResult> GetClientInfo()
        {
            var clientInfo = await _codeRepository.GetClientTutorials();
            var result = _mapper.Map<IEnumerable<ClientDto>>(clientInfo);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        //  [Route("/api/tutorial")]
        public async Task<IActionResult> GetClientById(int id)
        {

            var clientInfo = await _codeRepository.GetClientById(id);
            if (clientInfo == null)
                return NotFound();

            var result = _mapper.Map<ClientDto>(clientInfo);
            return Ok(result);
        }

        //

        [HttpPost("/api/newClient")]
        public async Task<ActionResult<ClientDto>> CreateClient(
     [FromBody] ClientForCreateDto client)
        {
            if (client == null) return BadRequest();

           

            if (!ModelState.IsValid) return BadRequest(ModelState);

            //*   if (!await _cityInfoRepository.CityExists(cityId)) return NotFound();*//*

            var finalClient = _mapper.Map<Client>(client);

            _codeRepository.AddClient(finalClient);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            var createdTutorial = _mapper.Map<TutorialDto>(finalClient);

            return CreatedAtAction("GetTutorialInfo", createdTutorial);
        }

        
        [HttpPut("{id}/updateclient")]
        public async Task<ActionResult> UpdateClient(int id, [FromBody] ClientForUpdateDto client)
        {
            if (client == null) return BadRequest();

    
            if (!ModelState.IsValid) return BadRequest();

            if (!await _codeRepository.ClientExists(id)) return NotFound();

            var clientEntity = await _codeRepository.GetClientById(id);
            if (client == null) return NotFound();

            _mapper.Map(client, clientEntity);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem ocurred while handling your request");
            }

            return NoContent();
        }

        //

        [HttpDelete("{ClientId}/api/client/")]
        public async Task<IActionResult> DeleteTutorial(int ClientId)
        {
            if (!await _codeRepository.ClientExists(ClientId)) return NotFound();

            var tutorialEntityForClient = await _codeRepository.GetClientById(ClientId);
            if (tutorialEntityForClient == null) return NotFound();

            //_cityInfoRepository.DeletePointOfInterest(pointOfInterestEntity);

            _codeRepository.DeleteClient(tutorialEntityForClient);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();

        }

    }
}
