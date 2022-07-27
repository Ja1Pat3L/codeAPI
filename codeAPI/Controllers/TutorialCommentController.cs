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

        [HttpPost("/api/newcommentfortutorial")]
        public async Task<ActionResult<TutorialCommentDto>> CreateTutorial(
         [FromBody] TutorialCommentForCreateDto comment)
        {
            if (comment == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            /*   if (!await _cityInfoRepository.CityExists(cityId)) return NotFound();*/

            var finalTutorial = _mapper.Map<TutorialComment>(comment);

            _codeRepository.AddTutorialComment(finalTutorial);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            var createdTutorialcomment = _mapper.Map<TutorialCommentDto>(finalTutorial);

            return CreatedAtAction("GetTutorialInfo", createdTutorialcomment);
        }

        [HttpPut("{id}/updatecomment")]
        public async Task<ActionResult> UpdateClient(int id, [FromBody] TutorialCommentForUpdateDto comment)
        {
            if (comment == null) return BadRequest();


            if (!ModelState.IsValid) return BadRequest();


            var commentEntity = await _codeRepository.GetTutorialComments(id);
            if (comment == null) return NotFound();

            _mapper.Map(comment, commentEntity);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem ocurred while handling your request");
            }

            return NoContent();
        }

        //
/*
        [HttpDelete("{tutorialId}/api/comment/")]
        public async Task<IActionResult> DeleteTutorialComment(int tutorial_Id)
        {

            var entity = await _codeRepository.GetTutorialComments(tutorial_Id);
            if (entity == null) return NotFound();



            _codeRepository.DeleteTutorialComment(entity);

            if (!await _codeRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();*/

        }

    }

