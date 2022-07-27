using System;
using System.ComponentModel.DataAnnotations;

namespace codeAPI.DTOs
{
    public class TutorialCommentForCreateDto
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage= "Client ID Required" )]
        public int ClientId { get; set; }

        [Required(ErrorMessage ="Tutorial ID Required")]
        public int? TutorialId { get; set; }

        [Required(ErrorMessage = "Comment required")]
        public string TutorialComment1 { get; set; }
        public DateTime? TutorialCommentTimestamp { get; set; }
    }
}
