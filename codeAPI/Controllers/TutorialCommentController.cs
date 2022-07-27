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

        //[HttpPost("/api/newcommentfortutorial{}")]
        //public async Task<ActionResult<TutoriaCommentsDto>> CreateCommentsl(
        // [FromBody] TutorialCommentForCreateDto comment)
        //{
        //    if (comment == null) return BadRequest();

        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    var finalcomment = _mapper.Map<TutorialComment>(comment);

        //    _codeRepository.AddTutorialComment(finalcomment);

        //    if (!await _codeRepository.Save())
        //    {
        //        return StatusCode(500, "A problem happened while handling your request");
        //    }

        //    var createdTutorial = _mapper.Map<TutoriaCommentsDto>(finalcomment);

        //    return CreatedAtAction("GetTutorial", createdTutorial);
        //}



    }

}
