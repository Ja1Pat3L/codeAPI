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
        /*Instances Created for Repository (codeRepository) and Auto Mapper (IMapper)*/
        #region INSTANCES
        private IcodeRepository _codeRepository;
        private readonly IMapper _mapper;
        #endregion

        /*Class Constructor with above Instances as parameters*/
        #region CONSTRUCTOR
        public TutorialCommentController(IcodeRepository codeRepository, IMapper mapper)
        {
            _codeRepository = codeRepository;
            _mapper = mapper;
        }
        #endregion

        /*Method- Getting List of Comments for Tutorials using Tutorial Id*/
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

        /*Method- Adding Comments*/
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

        /*Method- Delete Comment using Client Id and Tutorial Id*/
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

