﻿using AutoMapper;
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
        #region INSTANCES
        private IcodeRepository _codeRepository;
        private Client finalclient;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public ClientController(IcodeRepository codeRepository, IMapper mapper)
        {
            _codeRepository = codeRepository;
            _mapper = mapper;
        }
        #endregion

        #region GET CLIENT
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

        #endregion

        #region POST CLIENT
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

            var Createdclient = _mapper.Map<ClientForCreateDto>(finalClient);

            return Ok(Createdclient);
        }
        #endregion

        #region PUT CLIENT
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
        #endregion

        #region DELETE CLIENT 
        [HttpDelete("{ClientId}/api/client/")]
        public async Task<IActionResult> DeleteClient(int ClientId)
        {
            if (!await _codeRepository.ClientExists(ClientId)) return NotFound();

            var entity = await _codeRepository.GetClientById(ClientId);
            if (entity == null) return NotFound();


            _codeRepository.DeleteClient(entity);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();

        }
        #endregion

    }
}
