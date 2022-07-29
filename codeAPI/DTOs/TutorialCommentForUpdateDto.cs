using System;
using System.ComponentModel.DataAnnotations;
namespace codeAPI.DTOs
{
    public class TutorialCommentForUpdateDto
    {

        [Required(ErrorMessage = "Client Id Required")]
        public int ClientId { get; set; }


        [Required(ErrorMessage = "Tutorial Id Required")]
        public int? TutorialId { get; set; }

        [Required(ErrorMessage ="Tutorial Comment Required")]
        public string TutorialComment1 { get; set; }
       
    }
}
