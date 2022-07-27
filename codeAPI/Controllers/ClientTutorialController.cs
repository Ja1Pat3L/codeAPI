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
            if(clientTutorialInfo==null)
                return NotFound();
            
            var result = _mapper.Map<ClientTutorialDto>(clientTutorialInfo);
            return Ok(result);
        }
    }
}
