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

        #region INSTANCES
        private IcodeRepository _codeRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public TutorialCommentController(IcodeRepository codeRepository, IMapper mapper)
        {
            _codeRepository = codeRepository;
            _mapper = mapper;
        }
        #endregion

        #region GET COMMENT
        [HttpGet]
        [Route("/api/commentsfortutorial{tutorial_id}")]

        public async Task<IActionResult> GetTutorialComments(int tutorial_id)
        {
            var info = await _codeRepository.GetTutorialComments(tutorial_id);
            var result = _mapper.Map<IEnumerable<TutorialComment>>(info);
            return Ok(result);

        }
        #endregion

        #region POST COMMENT

        [HttpPost("/api/newcommentfortutorial")]
        public async Task<ActionResult<TutorialCommentDto>> CreateTutorialComment(
         [FromBody] TutorialCommentForCreateDto comment)
        {

            if (comment == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var finalTutorial = _mapper.Map<TutorialComment>(comment);

            _codeRepository.AddTutorialComment(finalTutorial);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            var createdTutorialcomment = _mapper.Map<TutorialCommentDto>(finalTutorial);

            return Ok(createdTutorialcomment);
        }
        #endregion

        #region PUT COMMENT

        /*Update not working error mapping */

        [HttpPut("{client_id}/updatecomment/{tutorial_id}")]
        public async Task<ActionResult> UpdateClient([FromBody] TutorialCommentForUpdateDto comment)
        {
            if (comment == null) return BadRequest();


            if (!ModelState.IsValid) return BadRequest();


            var commentEntity = await _codeRepository.GetTutorialCommentsForClient((int)comment.ClientId, (int)comment.TutorialId);
            if (comment == null) return NotFound();

            _mapper.Map(comment, commentEntity);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem ocurred while handling your request");
            }

            return NoContent();
        }

        #endregion

        #region DELETE COMMENT
        [HttpDelete("/api/comment/{client_id}/{tutorial_id}")]
        public async Task<IActionResult> DeleteTutorialComment(int client_id,int tutorial_id)
        {

            var entity = await _codeRepository.GetTutorialCommentsForClient(client_id,tutorial_id);
            if (entity == null) return NotFound();
            _codeRepository.DeleteTutorialComment(entity);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();

        }
        #endregion

    }
}

